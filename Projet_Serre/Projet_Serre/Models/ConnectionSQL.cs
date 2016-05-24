using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Projet_Serre.Models
{
    public class ConnectionSQL
    {
        private string serveur;
        private string baseDeDonnée;
        private string utilisateur;
        private string motDePasse;



        public ConnectionSQL()
        {
        }

        private MySqlConnection Initialisation()
        {

            serveur = "localhost";
            baseDeDonnée = "projet_serre";
            utilisateur = "projet";
            motDePasse = "serre";
            string connectionString;
            connectionString =  "SERVER=" + serveur + ";" + "DATABASE=" +
            baseDeDonnée + ";" + "UID=" + utilisateur + ";" + "PASSWORD=" + motDePasse + ";"+ "Convert Zero Datetime = True;"; 
            
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

        private MySqlConnection OuvrirConnection()
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

        public int Ajouter(string query)
        {      
            int id = 0;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                 
                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                id = msdr.GetInt32(0);

                connection.Close();
            }
            return id;
        }

        public void Modifier(string query)
        {
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Supprimer(string query)
        {
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SelectionnerIdProfil(int idProfil)
        {
            string query = "SELECT * FROM profil WHERE id='" + idProfil + "'";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteReader();
                connection.Close();
            }

        }

        public List<Profil> ListerProfil()
        {
            string query = "SELECT * FROM profil";
            List<Profil> profils = new List<Profil>();
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();
                while (msdr.Read())
                {
                    Profil profil = new Profil()
                    {
                        Id = msdr.GetInt32(0),
                        Nom = msdr.GetString(1),
                    };
                    profils.Add(profil);
                }
                msdr.Close();

                profils.ForEach(p => p.Conditions = ListerReglage(p.Id));
                connection.Close();
            }
            return profils;
        }

        public void SupprimerListReglage(int idProfil)
        {
            string query = "DELETE FROM reglage WHERE id_profil='" + idProfil + "'";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Reglage> ListerReglage()
        {

            string query = "SELECT * FROM reglage";
            List<Reglage> reglages = null;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                reglages = new List<Reglage>();
                while (msdr.Read())
                {
                    Reglage reglage = new Reglage()
                    {
                        Id = msdr.GetInt32(0),
                        Duree = new TimeSpan(msdr.GetInt32(1),0,0,0,0),
                        Lumiere = msdr.GetDouble(2),
                        TemperatureInterieur = msdr.GetDouble(3),
                        Humidite = msdr.GetDouble(4),
                        Vent = msdr.GetDouble(5),
                    };
                    reglages.Add(reglage);
                }

                connection.Close();
            }

            return reglages;
        }

        public List<Reglage> ListerReglage(int idProfil)
        {

            string query = "SELECT * FROM reglage WHERE id_profil = '" + idProfil + "'";
            List<Reglage> reglages = null;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();
                
                reglages = new List<Reglage>();
                while (msdr.Read())
                {
                    Reglage reglage = new Reglage()
                    {
                        Id = msdr.GetInt32(0),
                        Duree = new TimeSpan(msdr.GetInt32(1), 0, 0, 0, 0),
                        Lumiere = msdr.GetDouble(2),
                        TemperatureInterieur = msdr.GetDouble(3),
                        Humidite = msdr.GetDouble(4),
                        Vent = msdr.GetDouble(5),
                    };
                    reglages.Add(reglage);
                }

                connection.Close();
            }

            return reglages;
        }

        public int Profil_Actuel_Id()
        {
            int id_profil_actuel = 0;
            string query = "SELECT id_profil FROM profil_actuel";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

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

        public void Modifier_Profil_Actuel(int id_profil, DateTime date)
        {
            string query = "UPDATE profil_actuel SET id_profil='"+ id_profil +"', date='"+date.ToString("yyyy-MM-dd") +"'";

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                connection.Close();
            }
        }

        public LigneHistorique DerniereEntreeHistorique()
        {
            LigneHistorique temp = null;
            string query = "SELECT * FROM historique ORDER BY date DESC LIMIT 1";

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                temp = new LigneHistorique()
                {
                    Id = msdr.GetInt32(0),
                    Date = msdr.GetDateTime(1),
                    Lumiere = msdr.GetDouble(2),
                    TemperatureInterieur = msdr.GetDouble(3),
                    TemperatureExterieur = msdr.GetDouble(4),
                    Humidite = msdr.GetDouble(5),
                    Id_profil = msdr.GetInt32(6),
                    Id_reglage = msdr.GetInt32(7),
                };
                connection.Close();
            }
            return temp;
        }

        public List<LigneHistorique> EntreeHistorique(int nbEntrer)
        {
            List<LigneHistorique> ligneHistorique = null;
            
            string query = "SELECT * FROM historique ORDER BY date DESC LIMIT " + nbEntrer;

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                ligneHistorique = new List<LigneHistorique>();
                while (msdr.Read())
                {
                    
                    LigneHistorique temp = new LigneHistorique()
                    {
                        Id = msdr.GetInt32(0),
                        Date = msdr.GetDateTime(1),
                        Lumiere = msdr.GetDouble(2),
                        TemperatureInterieur = msdr.GetDouble(3),
                        TemperatureExterieur = msdr.GetDouble(4),
                        Humidite = msdr.GetDouble(5),
                        Id_profil = msdr.GetInt32(6),
                        Id_reglage = msdr.GetInt32(7),
                    };
                    ligneHistorique.Add(temp);
                }

                connection.Close();
            }
            return ligneHistorique;
        }
    }
}