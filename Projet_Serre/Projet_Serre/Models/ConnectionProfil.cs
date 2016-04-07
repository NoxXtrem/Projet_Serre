    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class ConnectionProfil
    {
        ConnectionSQL connection;
        public ConnectionProfil()
        {
            connection = new ConnectionSQL();
        }

        public int Ajouter(Profil profil)
        {
            string query = "INSERT INTO projet_serre.profil (nom) VALUES ('" + profil.Nom + "'); SELECT LAST_INSERT_ID();";
            return connection.Ajouter(query);
        }

        public void Modifier(int id, Profil profil)
        {
            string query = "UPDATE profil SET nom='" + profil.Nom + "'WHERE id='" + id + "'";
            connection.Modifier(query);
        }

        public void Supprimer(int idProfil)
        {
            string query = "DELETE FROM profil WHERE id='" + idProfil + "'; DELETE FROM reglage WHERE id_profil='" + idProfil + "'";
            connection.Supprimer(query);
        }

        public List<Profil> ListerProfil()
        {
            return connection.ListerProfil();
        }

        public void SelectionnerIdProfil(int idProfil)
        {
            connection.SelectionnerIdProfil(idProfil);
        }
    }

}