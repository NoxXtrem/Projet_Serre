using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Models
{
    public class ApercuViewModel
    {
        public string NomProfilActuel { get; set; }
        public int IdProfilActuel { get; set; }
        public int NombreDeJours { get; set; }
        public double TemperatureInterieurCapteur { get; set; }
        public double TemperatureExterieurCapteur { get; set; }
        public double TemperatureInterieurProfil { get; set; }
        public double HumiditeCapteur { get; set; }
        public double HumiditeProfil { get; set; }
        public double LumiereCapteur { get; set; }
        public double VentCapteur { get; set; }
        public string DateDerniereMaJ { get; set; }
    }
}