using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Application_Reguler_Serre
{
    class ConnectionSQL
    {
        private string serveur;
        private string baseDeDonnée;
        private string utilisateur;
        private string motDePasse;
        Program p = new Program();

        public ConnectionSQL()
        {
        }

        private SqlConnection Initialisation()
        {

            serveur = "localhost";
            baseDeDonnée = "projet_serre";
            utilisateur = "projet";
            motDePasse = "serre";
            string connectionString;
            connectionString = "SERVER=" + serveur + ";" + "DATABASE=" +
            baseDeDonnée + ";" + "UID=" + utilisateur + ";" + "PASSWORD=" + motDePasse + ";";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
        private SqlConnection OuvrirConnection()
        {
            try
            {
                SqlConnection connection = Initialisation();
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
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

        public int Reponse()
        {

            string query = "SELECT reponse FROM reguler ";
            int reponse = 0;
            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                reponse = msdr.GetInt32(0);

                connection.Close();
            }
            return reponse;
        }

        public void ModifierReponse(int reponse)
        {
            string query = "UPDATE reguler SET reponse='" + reponse + "'";
            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader msdr = cmd.ExecuteReader();
                connection.Close();
            }
        }

        public void AjoutHistorique()
        {
            string query = "INSERT INTO historique (date,lumiere,temperatureInterieur,temperatureExterieur,humidite,id_profil) VALUES('"
                + p.Date.ToString("yyyy-MM-dd") + "','" + p.Lumiere.ToString("F", CultureInfo.InvariantCulture) + "','" + p.TemperatureInterieur.ToString("F", CultureInfo.InvariantCulture) + "','" + p.TemperatureExterieur.ToString("F", CultureInfo.InvariantCulture) + "','" + p.Humidite.ToString("F", CultureInfo.InvariantCulture) + "')";

            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
            }

        }
    }
}