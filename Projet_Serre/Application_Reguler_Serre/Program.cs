using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Reguler_Serre
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionSQL csql = new ConnectionSQL();
            GestionCapteur gc = new GestionCapteur();
            GestionActionneur ga = new GestionActionneur();
            int reponse;

            while (true)
            {           
                reponse = csql.Reponse();

                if (reponse == 1)
                {
                    //Lire les capteurs
                    double lumiereMesure = gc.CapteurEnso.Valeur;
                    //...

                    //Lire le profil actuel et sa date de début dans la BDD
                    Profil p = null;
                    DateTime dateDebut = DateTime.Now;
                    //...

                    //Enregistrer les valeurs dans la BDD
                    csql.AjoutHistorique(DateTime.Now, lumiereMesure, 0,0,0, p.Id);

                    if (p != null)
                    {
                        //Choisir le bon réglage
                        Reglage r = p.SelectionnerReglage(lumiereMesure, dateDebut);

                        //Enregistrer le dernier réglage dans la BDD
                        //...

                        //Controller les actionneurs
                        ga.Chauffage.Commande = 25; //r.TemperatureInterieur;
                        //...
                    }
                    
                }
                System.Threading.Thread.Sleep(60000);
            }
        }
    }
}
