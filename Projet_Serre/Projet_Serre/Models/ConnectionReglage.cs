using System;
using System.Collections.Generic;
using System.Globalization;
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
                + reglage.Date.ToString("yyyy-MM-dd") + "','" + reglage.Lumiere.ToString("F", CultureInfo.InvariantCulture) + "','" + reglage.Temperature.ToString("F", CultureInfo.InvariantCulture) + "','" + reglage.Humidite.ToString("F", CultureInfo.InvariantCulture) + "','" + reglage.Vent.ToString("F", CultureInfo.InvariantCulture) + "','" + idProfil + "'); SELECT LAST_INSERT_ID();";
            return connection.Ajouter(query);
        }

        public void Modifier(int id, Reglage reglage)
        {
            string query = "UPDATE reglage SET date='" + reglage.Date.ToString("yyyy-MM-dd") + "', lumiere='" + reglage.Lumiere.ToString("F", CultureInfo.InvariantCulture) + "', temperature='" + reglage.Temperature.ToString("F", CultureInfo.InvariantCulture) + "', humidite='" + reglage.Humidite.ToString("F", CultureInfo.InvariantCulture) + "', vent='" + reglage.Vent.ToString("F", CultureInfo.InvariantCulture) + "' WHERE id='" + id + "'";
            connection.Modifier(query);
        }

        public void Supprimer(int id)
        {
            string query = "DELETE FROM reglage WHERE id='" + id + "'";
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