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
            int reponse = 1;
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

        public void AjoutHistorique(DateTime date, double lumiere, double temperatureInterieur, double temperatureExterieur, double humidite, int idProfil, int idReglage)
        {
            string query = "INSERT INTO historique (date,lumiere,temperatureInterieur,temperatureExterieur,humidite,id_profil,id_reglage) VALUES('"
                + date + "','" 
                + lumiere.ToString("F", CultureInfo.InvariantCulture) 
                + "','" + temperatureInterieur.ToString("F", CultureInfo.InvariantCulture) 
                + "','" + temperatureExterieur.ToString("F", CultureInfo.InvariantCulture) 
                + "','" + humidite.ToString("F", CultureInfo.InvariantCulture)
                + "','" + idProfil
                + "','" + idReglage
                + "')";

            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
            }

        }

        public int Profil_Actuel_Id()
        {
            int id_profil_actuel = 0;
            string query = "SELECT id_profil FROM profil_actuel";
            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader msdr = cmd.ExecuteReader();

                msdr.Read();
                id_profil_actuel = msdr.GetInt32(0);

                connection.Close();
            }


            return id_profil_actuel;
        }

        public DateTime Profil_Actuel_Date()
        {
            DateTime date_profil_actuel = DateTime.Now;
            string query = "SELECT date FROM profil_actuel";

            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                date_profil_actuel = msdr.GetDateTime(0);

                connection.Close();
            }

            return date_profil_actuel;
        }

        public Reglage SelectionnerReglage(int idProfil, double lumiere, DateTime dateDeDebut)
        {
            string query = "SELECT * FROM reglage WHERE id_profil = '" + idProfil + "' AND duree >= '"+ (DateTime.Now - dateDeDebut).Days + "' AND lumiere >='"+lumiere+"' ORDER BY duree,lumiere LIMIT 1";
            Reglage reglage = null;
            SqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader msdr = cmd.ExecuteReader();


                    reglage = new Reglage()
                    {
                        Id = msdr.GetInt32(0),
                        Duree = new TimeSpan(msdr.GetInt32(1), 0, 0, 0, 0),
                        Lumiere = msdr.GetDouble(2),
                        TemperatureInterieur = msdr.GetDouble(3),
                        Humidite = msdr.GetDouble(4),
                        Vent = msdr.GetDouble(5),
                    };
                   
                

                connection.Close();
            }

            return reglage;
        }
    }
}