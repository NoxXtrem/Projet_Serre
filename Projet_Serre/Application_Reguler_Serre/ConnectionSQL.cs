﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Application_Reguler_Serre
{
    class ConnectionSQL
    {
       

        public ConnectionSQL()
        {
        }

        private MySqlConnection Initialisation() // on envoie la requête pour pouvoir se connecter à la Bdd
        {
            string connectionString;
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["serveur"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
        private MySqlConnection OuvrirConnection() // on fait une connection vers la Bdd
        {
            try
            {
                MySqlConnection connection = Initialisation();
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Impossible de se connecter au serveur.Contacter l'administrateur");
                        break;

                    case 1045:
                        Console.WriteLine("nom d'utilisateur/mot de passe invalide, s'il vous plaît réessayer");
                        break;
                }
                return null;
            }
        }

        public int Reponse() // on retourne une valeur 0 ou 1 pour savoir si on met en marche l'application
        {

            string query = "SELECT reponse FROM reguler ";
            int reponse = 0;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                reponse = msdr.GetInt32(0);

                connection.Close();
            }
            return reponse;
        }

        public void ModifierReponse(int reponse) // on modifie la valeur pour allumer ou éteindre l'application
        {
            string query = "UPDATE reguler SET reponse='" + reponse + "'";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader msdr = cmd.ExecuteReader();
                connection.Close();
            }
        }

        public void AjoutHistorique(DateTime date, double lumiere, double temperatureInterieur, double temperatureExterieur, double humidite, int idProfil, int idReglage) // on ajoute les valeurs recueillis par les capteurs à la table historique
        {
            string query = "INSERT INTO historique (date,lumiere,temperatureInterieur,temperatureExterieur,humidite,id_profil,id_reglage) VALUES('"
                + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" 
                + lumiere.ToString("F", CultureInfo.InvariantCulture) 
                + "','" + temperatureInterieur.ToString("F", CultureInfo.InvariantCulture) 
                + "','" + temperatureExterieur.ToString("F", CultureInfo.InvariantCulture) 
                + "','" + humidite.ToString("F", CultureInfo.InvariantCulture)
                + "'," + (idProfil == 0 ? "NULL" : ( "'" + idProfil.ToString() + "'" ))
                + "," + (idReglage == 0 ? "NULL" : ("'" + idReglage.ToString() + "'" ))
                + ")";

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
            }

        }

        public int Profil_Actuel_Id() // on récupère l'id du profil actuel
        {
            int id_profil_actuel = 0;
            string query = "SELECT id_profil FROM profil_actuel";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                msdr.Read();
                if (msdr.IsDBNull(0))
                {
                    id_profil_actuel = 0;
                }
                else
                {
                    id_profil_actuel = msdr.GetInt32(0);
                }

                connection.Close();
            }


            return id_profil_actuel;
        }

        public DateTime Profil_Actuel_Date() // on récupère la date du profil actuel
        {
            DateTime date_profil_actuel = DateTime.Now;
            string query = "SELECT date FROM profil_actuel";

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                date_profil_actuel = msdr.GetDateTime(0);

                connection.Close();
            }

            return date_profil_actuel;
        }

        public Reglage SelectionnerReglage(int idProfil, double lumiere, DateTime dateDeDebut) // on détermine avec la date et la lumiere quel réglage on sélectionne pour pouvoir mettre en marche les actionneurs
        {
            string query = "SELECT * FROM reglage WHERE id_profil = '" + idProfil + "' AND duree >= '"+ (DateTime.Now - dateDeDebut).Days + "' AND lumiere >='"+lumiere+"' ORDER BY duree,lumiere LIMIT 1";
            Reglage reglage = null;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                if (msdr.Read())
                {

                    reglage = new Reglage()
                    {
                        Id = msdr.GetInt32(0),
                        Duree = new TimeSpan(msdr.GetInt32(1), 0, 0, 0, 0),
                        Lumiere = msdr.GetDouble(2),
                        TemperatureInterieur = msdr.GetDouble(3),
                        Humidite = msdr.GetDouble(4),
                        Vent = msdr.GetDouble(5),
                    };
                }
                

                connection.Close();
            }

            return reglage;
        }

        public int Id_Reglage(int idProfil, double lumiere, DateTime dateDeDebut) // on détermine avec la date et la lumiere quel id de reglage on récupère
        {
            string query = "SELECT id FROM reglage WHERE id_profil = '" + idProfil + "' AND duree >= '" + (DateTime.Now - dateDeDebut).Days + "' AND lumiere >='" + lumiere + "' ORDER BY duree,lumiere LIMIT 1";
            int id_reglage = 0;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                if (msdr.Read())
                {
                    id_reglage = msdr.GetInt32(0);
                }

                connection.Close();
            }

            return id_reglage;


        }
    }
}
