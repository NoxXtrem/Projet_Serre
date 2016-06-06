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

            while (true)
            {

                reponse = cs.Reponse();
                if (reponse == 1)
                {

                    InterfaceKit ifKit;

                    try
                    {
                        //Initialize the InterfaceKit object
                        ifKit = new InterfaceKit();

                        //Hook the basica event handlers
                        ifKit.Attach += new AttachEventHandler(ifKit_Attach);
                        ifKit.Detach += new DetachEventHandler(ifKit_Detach);
                        ifKit.Error += new ErrorEventHandler(ifKit_Error);

                        //Hook the phidget spcific event handlers
                        ifKit.InputChange += new InputChangeEventHandler(ifKit_InputChange);
                        ifKit.OutputChange += new OutputChangeEventHandler(ifKit_OutputChange);
                        ifKit.SensorChange += new SensorChangeEventHandler(ifKit_SensorChange);

                        //Open the object for device connections
                        ifKit.open();

                        //Wait for an InterfaceKit phidget to be attached
                        Console.WriteLine("Waiting for InterfaceKit to be attached...");
                        ifKit.waitForAttachment();

                        humidite = Math.Round((((ifKit.sensors[7].Value) * 0.1909) - 40.2), 1);
                        temperature = Math.Round((((ifKit.sensors[6].Value) * 0.22222) - 61.11), 1);
                        temperatureEx = Math.Round((((ifKit.sensors[4].Value) * 0.22222) - 61.11), 1);
                        luminosite = ifKit.sensors[5].Value;


                        id_profil = cs.Profil_Actuel_Id();
                        date_profil = cs.Profil_Actuel_Date();
                        id_reglage = cs.Id_Reglage(id_profil, luminosite, date_profil);
                        cs.AjoutHistorique(DateTime.Now, luminosite, temperature, temperatureEx, humidite, id_profil, id_reglage);

                        //Wait for user input so that we can wait and watch for some event data 
                        //from the phidget
                        Console.WriteLine("Press any key to end...");
                        Console.Read();

                        //User input was rad so we'll terminate the program, so close the object
                        ifKit.close();

                        //set the object to null to get it out of memory
                        ifKit = null;


                        //If no expcetions where thrown at this point it is safe to terminate 
                        //the program
                        Console.WriteLine("ok");

                        cs.SelectionnerReglage(id_profil, luminosite, DateTime.Now);

                        if ()
                        {

                        }

                        if ()
                        {

                        }

                    }
                    catch (PhidgetException ex)
                    {
                        Console.WriteLine(ex.Description);
                    }
                }

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
