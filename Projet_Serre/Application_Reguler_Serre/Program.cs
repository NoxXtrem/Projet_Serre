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
                    Reglage r = null;
                    DateTime dateDebut = DateTime.Now;

                    Profil p = null;
                    int id_profilActuel = csql.Profil_Actuel_Id();
                    r = csql.SelectionnerReglage(id_profilActuel, lumiereMesure, dateDebut);
                    dateDebut = csql.Profil_Actuel_Date();

                    //...

                    if (r != null)
                    {
                        //Choisir le bon réglage
                       

                        //Enregistrer le dernier réglage dans la BDD
                        //...

                        //Controller les actionneurs
                        ga.Chauffage.Commande = 25; //r.TemperatureInterieur;
                        //...
                    }

                    //Enregistrer les valeurs dans la BDD
                    csql.AjoutHistorique(DateTime.Now, lumiereMesure, 0, 0, 0, p != null ? p.Id : 0, r != null ? r.Id : 0);
                    
                }
                System.Threading.Thread.Sleep(60000);
            }
        }
    }
}
