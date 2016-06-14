using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidgets;
using Phidgets.Events;
using System.Threading;
using System.Data.SqlClient;

namespace Application_Reguler_Serre
{
    class Program
    {
        static void Main(string[] args)
        {
            int reponse;
            double luminosite;
            double temperature;
            double temperatureEx;
            double humidite;
            int id_profil;
            int id_reglage;
            DateTime date_profil;
            ConnectionSQL cs = new ConnectionSQL();
            Reglage reglage;

            while (true)
            {

                reponse = cs.Reponse();
                if (reponse == 1)
                {

                    InterfaceKit ifKit;
                    InterfaceKit ifKitRelay;

                    try
                    {
                        //Initialize the InterfaceKit object
                        ifKit = new InterfaceKit();
                        ifKitRelay = new InterfaceKit();

                        //Hook the basica event handlers
                        ifKit.Attach += new AttachEventHandler(ifKit_Attach);
                        ifKit.Detach += new DetachEventHandler(ifKit_Detach);
                        ifKit.Error += new ErrorEventHandler(ifKit_Error);

                        //Hook the phidget spcific event handlers
                        ifKit.InputChange += new InputChangeEventHandler(ifKit_InputChange);
                        ifKit.OutputChange += new OutputChangeEventHandler(ifKit_OutputChange);
                        ifKit.SensorChange += new SensorChangeEventHandler(ifKit_SensorChange);

                        //Open the object for device connections
                        ifKit.open(174971);
                        ifKitRelay.open(87522);

                        //Wait for an InterfaceKit phidget to be attached
                        Console.WriteLine("Waiting for InterfaceKit to be attached...");
                        ifKit.waitForAttachment();

                        // conversion des valeurs réupérer par les capteurs pour avoir des valeurs justes
                        humidite = Math.Round((((ifKit.sensors[7].Value) * 0.1909) - 40.2), 1);
                        temperature = Math.Round((((ifKit.sensors[6].Value) * 0.22222) - 61.11), 1);
                        temperatureEx = Math.Round((((ifKit.sensors[4].Value) * 0.22222) - 61.11), 1);
                        luminosite = ifKit.sensors[5].Value;

                        Console.WriteLine("humidite :"+humidite);
                        Console.WriteLine("temperature :"+temperature);

                        // on récupère l'id la date du profil actuel et l'id du réglage pour ajouter les valeurs recueillis par les capteurs à la table historique
                        id_profil = cs.Profil_Actuel_Id();
                        date_profil = cs.Profil_Actuel_Date();
                        id_reglage = cs.Id_Reglage(id_profil, luminosite, date_profil);
                        cs.AjoutHistorique(DateTime.Now, luminosite, temperature, temperatureEx, humidite, id_profil, id_reglage);



                       reglage = cs.SelectionnerReglage(id_profil, luminosite, DateTime.Now);
                        if (reglage != null)
                        {
                            // on met plusieurs conditions pour savoir quel actionneurs allumer ou éteindre selon le réglage précédamment sélectionner
                            //inversement des true et false
                            if (reglage.Humidite < humidite)
                            {
                                ifKitRelay.outputs[0] = false;
                                ifKitRelay.outputs[1] = true;
                                //allumer ventilateur
                                //allumer vanne d'arrosage
                            }
                            else
                            {
                                ifKitRelay.outputs[0] = true;
                                ifKitRelay.outputs[1] = false;
                                //allumer vanne d'arrosage
                                //allumer ventilateur
                            }

                            if (reglage.TemperatureInterieur < temperature)
                            {
                                ifKitRelay.outputs[0] = false;
                                ifKitRelay.outputs[2] = true;
                                //allumer ventilateur
                                //eteindre chauffage
                            }
                            else
                            {
                                ifKitRelay.outputs[0] = true;
                                ifKitRelay.outputs[2] = false;
                                //allumer chauffage
                                //eteindre ventilateur
                            }

                            if (luminosite <= 20)
                            {
                                ifKitRelay.outputs[3] = false;
                            }
                            else
                            {
                                ifKitRelay.outputs[3] = true;
                            }
                        }
                        //User input was rad so we'll terminate the program, so close the object
                        ifKit.close();
                        ifKitRelay.close();

                        //set the object to null to get it out of memory
                        ifKit = null;
                        ifKitRelay = null;

                    }
                    catch (PhidgetException ex)
                    {
                        Console.WriteLine(ex.Description);
                    }
                }
                //TIMER de 10s actuellment
                Thread.Sleep(10000);
            }

           
        }

        //Attach event handler...Display the serial number of the attached InterfaceKit 
        //to the console
        static void ifKit_Attach(object sender, AttachEventArgs e)
        {
            Console.WriteLine("InterfaceKit {0} attached!",
                                e.Device.SerialNumber.ToString());
        }

        //Detach event handler...Display the serial number of the detached InterfaceKit 
        //to the console
        static void ifKit_Detach(object sender, DetachEventArgs e)
        {
            Console.WriteLine("InterfaceKit {0} detached!",
                                e.Device.SerialNumber.ToString());
        }

        //Error event handler...Display the error description to the console
        static void ifKit_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Description);
        }

        //Input Change event handler...Display the input index and the new value to the 
        //console
        static void ifKit_InputChange(object sender, InputChangeEventArgs e)
        {
            Console.WriteLine("Input index {0} value (1)", e.Index, e.Value.ToString());
        }

        //Output change event handler...Display the output index and the new valu to 
        //the console
        static void ifKit_OutputChange(object sender, OutputChangeEventArgs e)
        {
            Console.WriteLine("Output index {0} value {0}", e.Index, e.Value.ToString());
        }

        //Sensor Change event handler...Display the sensor index and it's new value to 
        //the console
        static void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
        {
            Console.WriteLine("Sensor index {0} value {1}", e.Index, e.Value);
        }
    }
}
