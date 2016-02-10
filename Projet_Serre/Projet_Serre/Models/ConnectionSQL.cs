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
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
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

        public void AjouterProfil(string nom)
        {
            string query = "INSERT INTO profil (nom) VALUES('"+nom+"')";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                this.FermerConnection();
            }
        }

        public void ModifierProfil(string nom)
        {
            string query = "UPDATE profil SET nom='"+nom+"', WHERE name='"+nom+"'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                this.FermerConnection();
            }
        }

        public void SupprimerProfil(string nom)
        {
            string query = "DELETE FROM profil WHERE nom='"+nom+"'";

            if (this.OuvrirConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.FermerConnection();
            }
        }
    }
}