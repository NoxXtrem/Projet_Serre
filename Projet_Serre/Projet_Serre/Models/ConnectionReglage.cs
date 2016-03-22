using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class ConnectionReglage
    {
        ConnectionSQL connection;
        public ConnectionReglage()
        {
            connection = new ConnectionSQL();
        }

        public int Ajouter(Reglage reglage, int idProfil)
        {
            string query = "INSERT INTO reglage (date,lumiere,temperature,humidite,vent,id_profil) VALUES('"
                + reglage.Date.ToString("yyyy-MM-dd") + "','" + reglage.Lumiere + "','" + reglage.Temperature + "','" + reglage.Humidite + "','" + reglage.Vent + "','" + idProfil + "'); SELECT LAST_INSERT_ID();";
            return connection.Ajouter(query);
        }

        public void Modifier(int id, Reglage reglage)
        {
            string query = "UPDATE reglage SET date='" + reglage.Date.ToString("yyyy-MM-dd") + "', lumiere='" + reglage.Lumiere + "', temperature='" + reglage.Temperature + "', humidite='" + reglage.Humidite + "', vent='" + reglage.Vent + "' WHERE id='" + id + "'";
            connection.Modifier(query);
        }

        public void Supprimer(int id)
        {
            string query = "DELETE FROM reglage WHERE nom='" + id + "'";
            connection.Supprimer(query);
        }

        public void SupprimerListReglage(int idProfil)
        {
            connection.SupprimerListReglage(idProfil);
        }

        public List<Reglage> ListerReglage(int idProfil)
        {
            return connection.ListerReglage(idProfil);
        }

        public List<Reglage> ListerReglage()
        {
            return connection.ListerReglage();
        }
    }
}