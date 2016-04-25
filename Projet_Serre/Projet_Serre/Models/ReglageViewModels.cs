using System;
using System.Collections.Generic;
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
        public string Date { get; set; }
        public double Lumiere { get; set; }
        public double TemperatureInterieur { get; set; }
        public double Humidite { get; set; }
        
    }
}