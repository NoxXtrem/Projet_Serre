using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Models
{
    public class ApercuViewModel
    {
        public string nomProfilActuel { get; set; }
        public string lienProfilActuel { get; set; }
        public double temperatureCapteur { get; set; }
        public double temperatureProfil { get; set; }
        public double humiditeCapteur { get; set; }
        public double humiditeProfil { get; set; }
        public double lumiereCapteur { get; set; }
        public double ventCapteur { get; set; }
        public string dateDerniereMaJ { get; set; }
    }
}