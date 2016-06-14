using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class ListReglageViewModel
    {
        public int IdProfil { get; set; }
        public string NomProfil { get; set; }
        public List<ReglageViewModel> Reglages { get; set; }

        public ListReglageViewModel() { }
        public ListReglageViewModel(List<Reglage> list, int idProfil = 0)
        {
            this.Reglages = new List<ReglageViewModel>();
            if (list != null)
            {
                list.ForEach(r => Reglages.Add(new ReglageViewModel(r, idProfil)));
            }
            this.IdProfil = idProfil;
        }
    }
    public class ReglageViewModel
    {
        [Key]
        public int IdReglage { get; set; }
        public int IdProfil { get; set; }
        [DisplayName("Durée")]
        [Range(0, int.MaxValue, ErrorMessage="Le champ {0} doit être plus grand que {1}")]
        public int Duree { get; set; }
        [DisplayName("Lumière")]
        [Range(0, double.MaxValue, ErrorMessage = "Le champ {0} doit être plus grand que {1}")]
        public double Lumiere { get; set; }
        [DisplayName("Température")]
        public double TemperatureInterieur { get; set; }
        [Range(0,100)]
        [DisplayName("Humidité")]
        public double Humidite { get; set; }
        
        public ReglageViewModel() { }
        public ReglageViewModel(Reglage r, int idProfil = 0)
        {
            this.IdReglage = r.Id;
            this.IdProfil = idProfil;
            this.Duree = r.Duree.Days;
            this.Lumiere = r.Lumiere;
            this.TemperatureInterieur = r.TemperatureInterieur;
            this.Humidite = r.Humidite;
        }
    }
}