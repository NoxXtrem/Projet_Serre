using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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
        
    }

    public class HistoriqueViewModel
    {
        public List<LigneHistoriqueViewModel> Historique { get; set; }

        public HistoriqueViewModel() { }

        public string Labels
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                foreach (LigneHistoriqueViewModel lh in Historique)
                {
                    s.Append("\"").Append(lh.Date).Append("\",");
                }
                return s.Append("]").ToString();
            }
        }
        public string HumiditeData
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                foreach (LigneHistoriqueViewModel lh in Historique)
                {
                    s.Append(lh.Humidite.ToString("F", CultureInfo.InvariantCulture)).Append(",");
                }
                return s.Append("]").ToString();
            }
        }
        public string TemperatureInterieurData
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                foreach (LigneHistoriqueViewModel lh in Historique)
                {
                    s.Append(lh.TemperatureInterieur.ToString("F", CultureInfo.InvariantCulture)).Append(",");
                }
                return s.Append("]").ToString();
            }
        }
        public string TemperatureExterieurData
        {
            get
            {
                StringBuilder s = new StringBuilder("[");
                foreach (LigneHistoriqueViewModel lh in Historique)
                {
                    s.Append(lh.TemperatureExterieur.ToString("F", CultureInfo.InvariantCulture)).Append(",");
                }
                return s.Append("]").ToString();
            }
        }
        
    }
}