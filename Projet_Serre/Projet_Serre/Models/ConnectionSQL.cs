using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Projet_Serre.Models
{
    public class ConnectionSQL
    {

        private MySqlConnection connection;
        private string serveur;
        private string baseDeDonnée;
        private string utilisateur;
        private string motDePasse;

        public ConnectionSQL() { Initialisation(); }
       


        private void Initialisation()
        {

            serveur = "localhost";
            baseDeDonnée = "projet_serre";
            utilisateur = "projet";
            motDePasse = "serre";
            string connectionString;
            connectionString = "SERVER=" + serveur + ";" + "DATABASE=" +
            baseDeDonnée + ";" + "UID=" + utilisateur + ";" + "PASSWORD=" + motDePasse + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OuvrirConnection()
        {
            try
            {
                connection.Open();
                return true;
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
                return false;
            }
        }

        private bool FermerConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public int AjouterProfil(Profil profil)
        {

            string query = "INSERT INTO projet_serre.profil (nom) VALUES ('" + profil.Nom+ "'); SELECT LAST_INSERT_ID();";
            int idProfil = 0;
            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                 
                MySqlDataReader msdr = cmd.ExecuteReader();
                msdr.Read();
                idProfil = msdr.GetInt32(0);

                this.FermerConnection();
            }
            return idProfil;
        }

        public void ModifierProfil(int id, Profil profil)
        {
            string query = "UPDATE profil SET nom='"+ profil.Nom + "'WHERE id='"+ id + "'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.FermerConnection();
            }
        }

        public void SupprimerProfil(int idProfil)
        {
            string query = "DELETE FROM profil WHERE id='"+ idProfil + "'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.FermerConnection();
            }
        }

        public void SelectionnerIdProfil(int idProfil)
        {
            string query = "SELECT * FROM profil WHERE id='" + idProfil + "'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteReader();
                this.FermerConnection();
            }

        }

        public List<Profil> ListerProfil()
        {
            string query = "SELECT * FROM profil";
            List<Profil> profils = null;
            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

               profils = new List<Profil>();
                while (msdr.Read())
                {
                    Profil profil = new Profil()
                    {
                        Id = msdr.GetInt32(0),
                        Nom = msdr.GetString(1),
                    };
                    profils.Add(profil);
                }
                
                this.FermerConnection();
            }
            return profils;
        }

       public void AjouterReglage(Reglage reglage)
        {
            string query = "INSERT INTO reglage (date,lumiere,temperature,humidite,vent,id_profil) VALUES('"
                + reglage.Date+ "','" + reglage.Lumiere + "','" + reglage.Temperature + "','" + reglage.Humidite + "','" + reglage.Vent + "')";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                this.FermerConnection();
            }
        }

        public void ModifierReglage(int id, Reglage reglage)
        {
            string query = "UPDATE reglage SET date='" + reglage.Date + "', lumiere='" + reglage.Lumiere + "', temperature='" + reglage.Temperature + "', humidite='" + reglage.Humidite + "', vent='" + reglage.Vent + "', WHERE id='" + id + "'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.FermerConnection();
            }
        }

        public void SupprimerReglage(int id)
        {
            string query = "DELETE FROM reglage WHERE nom='" + id + "'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.FermerConnection();
            }
        }
    }
}