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
    }
    public class ReglageViewModel
    {
        [Key]
        public int IdReglage { get; set; }
        public int IdProfil { get; set; }
        [DisplayName("Durée")]
        public int Duree { get; set; }
        [DisplayName("Lumière")]
        public double Lumiere { get; set; }
        [DisplayName("Température")]
        public double TemperatureInterieur { get; set; }
        [DisplayName("Humidité")]
        public double Humidite { get; set; }
        
    }
}