using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class ListReglageViewModel
    {
        public List<Reglage> Reglages { get; set; }
    }
    public class ReglageViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public double Lumiere { get; set; }
        public double Temperature { get; set; }
        public double Humidite { get; set; }
        public double Vent { get; set; }
    }
}