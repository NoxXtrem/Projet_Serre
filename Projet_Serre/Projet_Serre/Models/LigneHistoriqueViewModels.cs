using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace Projet_Serre.Models
{
    public class LigneHistoriqueViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public double Lumiere { get; set; }
        public double TemperatureInterieur { get; set; }
        public double TemperatureExterieur { get; set; }
        public double Humidite { get; set; }
        public int Id_profil { get; set; }
        public int Id_reglage { get; set; }

        public LigneHistoriqueViewModel() { }
        public LigneHistoriqueViewModel(LigneHistorique lh)
        {
            this.Id = lh.Id;
            this.Date = lh.Date.ToString();
            this.Lumiere = lh.Lumiere;
            this.TemperatureExterieur = lh.TemperatureExterieur;
            this.TemperatureInterieur = lh.TemperatureInterieur;
            this.Humidite = lh.Humidite;
            this.Id_profil = lh.Id_profil;
            this.Id_reglage = lh.Id_reglage;
        }
    }

    public class HistoriqueViewModel
    {
        public List<LigneHistoriqueViewModel> Historique { get; set; }

        public HistoriqueViewModel() { }

        //On suppose que list est ordonné par date (Normalement fait par la requète SQL)
        public HistoriqueViewModel(List<LigneHistorique> list)
        {
            Historique = new List<LigneHistoriqueViewModel>();
            list.ForEach(lh => Historique.Add(new LigneHistoriqueViewModel(lh)));
        }

        public string Labels
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                Historique.ForEach(lh => s.Append("\"").Append(lh.Date).Append("\","));
                return s.Append("]").ToString();
            }
        }
        public string HumiditeData
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                Historique.ForEach(lh => s.Append(lh.Humidite.ToString("F", CultureInfo.InvariantCulture)).Append(","));
                return s.Append("]").ToString();
            }
        }
        public string TemperatureInterieurData
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                Historique.ForEach(lh => s.Append(lh.TemperatureInterieur.ToString("F", CultureInfo.InvariantCulture)).Append(","));
                return s.Append("]").ToString();
            }
        }
        public string TemperatureExterieurData
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                Historique.ForEach(lh => s.Append(lh.TemperatureExterieur.ToString("F", CultureInfo.InvariantCulture)).Append(","));
                return s.Append("]").ToString();
            }
        }
        
    }
}