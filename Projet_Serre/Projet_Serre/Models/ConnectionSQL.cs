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

        public int AjouterProfil(Profil profil)
        {

            string query = "INSERT INTO projet_serre.profil (nom) VALUES ('" + profil.Nom+ "'); SELECT LAST_INSERT_ID();";
            int idProfil = 0;
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                 
                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                idProfil = msdr.GetInt32(0);

                connection.Close();
            }
            return idProfil;
        }

        public void ModifierProfil(int id, Profil profil)
        {
            string query = "UPDATE profil SET nom='"+ profil.Nom + "'WHERE id='"+ id + "'";
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

        public void SupprimerProfil(int idProfil)
        {
            string query = "DELETE FROM profil WHERE id='"+ idProfil + "'; DELETE FROM reglage WHERE id_profil='"+idProfil+"'";
            List<Profil> profils = new List<Profil>();
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                profils.ForEach(p => SupprimerListReglage(p.Id));

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

       public int AjouterReglage(Reglage reglage,int idProfil)
        {
            int idReglage = 0;
            string query = "INSERT INTO reglage (date,lumiere,temperature,humidite,vent,id_profil) VALUES('"
                + reglage.Date.ToString("yyyy-MM-dd") + "','" + reglage.Lumiere + "','" + reglage.Temperature + "','" + reglage.Humidite + "','" + reglage.Vent + "','"+idProfil+"'); SELECT LAST_INSERT_ID();";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                idReglage = msdr.GetInt32(0); ;
                connection.Close();
            }
            return idReglage;
        }

        public void ModifierReglage(int id, Reglage reglage)
        {
            string query = "UPDATE reglage SET date='" + reglage.Date.ToString("yyyy-MM-dd") + "', lumiere='" + reglage.Lumiere + "', temperature='" + reglage.Temperature + "', humidite='" + reglage.Humidite + "', vent='" + reglage.Vent + "' WHERE id='" + id + "'";
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

        public void SupprimerReglage(int id)
        {
            string query = "DELETE FROM reglage WHERE nom='" + id + "'";
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
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
                        Date = msdr.GetDateTime(1),
                        Lumiere = msdr.GetDouble(2),
                        Temperature = msdr.GetDouble(3),
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
                        Date = msdr.GetDateTime(1),
                        Lumiere = msdr.GetDouble(2),
                        Temperature = msdr.GetDouble(3),
                        Humidite = msdr.GetDouble(4),
                        Vent = msdr.GetDouble(5),

                    };
                    reglages.Add(reglage);
                }

                connection.Close();
            }

            return reglages;
        }
    }
}