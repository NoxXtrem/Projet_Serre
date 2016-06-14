using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Projet_Serre.Models
{
    public class ConnectionSQL
    {

        public ConnectionSQL()
        {
        }

        private MySqlConnection Initialisation() // on envoie la requête pour pouvoir se connecter à la Bdd
        {

            
            string connectionString;
            connectionString =  System.Configuration.ConfigurationManager.ConnectionStrings["serveur"].ConnectionString;
            
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

        public int Ajouter(string query) // Ajout d'un réglage ou d'un profil
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

        public void Modifier(string query) // Modifier un réglage ou un profil
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

        public void Supprimer(string query) // Supprimer un réglage ou un profil
        {
            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void SelectionnerIdProfil(int idProfil) //On sélectionne un profil selon son id
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

        public List<Profil> ListerProfil() // on liste une liste de profil
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

        public void SupprimerListReglage(int idProfil) // on supprime un réglage selon un l'id d'un profil
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

        public List<Reglage> ListerReglage() // on liste une liste de réglage
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

        public List<Reglage> ListerReglage(int idProfil) // on liste une liste de réglage selon l'id
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

        public int Profil_Actuel_Id() // on selectionne l'id du profil actuel
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
                }else
                {
                    id_profil_actuel = msdr.GetInt32(0);
                }
                
                
                connection.Close();
            }


                return id_profil_actuel;
        }

        public DateTime Profil_Actuel_Date() // on selectionne la date du profil actuel
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

        public void Modifier_Profil_Actuel(int id_profil, DateTime date) // on modifie l'id ou/et la date du profil actuel
        {
            string query = "UPDATE profil_actuel SET id_profil="+ (id_profil != 0 ? ("'" + id_profil + "'") : "NULL") +", date='"+date.ToString("yyyy-MM-dd") +"'";

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                connection.Close();
            }
        }

        public LigneHistorique DerniereEntreeHistorique() // on retourne la derniere ligne ajouter à l'historique
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
                    Id_profil = msdr.IsDBNull(6) ? 0 : msdr.GetInt32(6),
                    Id_reglage = msdr.IsDBNull(7) ? 0 : msdr.GetInt32(7),
                };
                connection.Close();
            }
            return temp;
        }

        public List<LigneHistorique> EntreeHistorique(int nbEntrer) // on retourne x ligne du tableau historique sous forme de liste
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
                        Id_profil = msdr.IsDBNull(6) ? 0 : msdr.GetInt32(6),
                        Id_reglage = msdr.IsDBNull(7) ? 0 : msdr.GetInt32(7),
                    };
                    ligneHistorique.Add(temp);
                }

                connection.Close();
            }
            return ligneHistorique;
        }

        public void ChangerRegulation(int reguler)
        {
            string query = "UPDATE reguler SET reponse=" +reguler + "";

            MySqlConnection connection = OuvrirConnection();
            if (connection != null)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader msdr = cmd.ExecuteReader();

                connection.Close();
            }
        }
    }
}