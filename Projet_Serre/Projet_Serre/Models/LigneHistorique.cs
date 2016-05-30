using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class LigneHistorique
    {
        private int id;
        public int Id
        {
            get
            { return id; }
            set
            { id = value; }
        }
        private DateTime date;
        public DateTime Date
        {
            get
            { return date; }
            set
            { date = value; }
        }
        private double lumiere;
        public double Lumiere
        {
            get
            { return lumiere; }
            set
            { lumiere = value; }
        }
        private double temperatureInterieur;
        public double TemperatureInterieur
        {
            get
            { return temperatureInterieur; }
            set
            { temperatureInterieur = value; }
        }

        private double temperatureExterieur;
        public double TemperatureExterieur
        {
            get
            { return temperatureExterieur; }
            set
            { temperatureExterieur = value; }
        }

        private double humidite;
        public double Humidite
        {
            get
            { return humidite; }
            set
            { humidite = value; }
        }

        private int id_profil;
        public int Id_profil
        {
            get
            { return id_profil; }
            set
            { id_profil = value; }
        }

        private int id_reglage;
        public int Id_reglage
        {
            get
            { return id_reglage; }
            set
            { id_reglage = value; }
        }
    }
}