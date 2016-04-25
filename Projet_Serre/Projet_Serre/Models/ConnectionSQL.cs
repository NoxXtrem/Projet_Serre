﻿using System;
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
                        Date = msdr.GetDateTime(1),
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
                        Date = msdr.GetDateTime(1),
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
    }
}