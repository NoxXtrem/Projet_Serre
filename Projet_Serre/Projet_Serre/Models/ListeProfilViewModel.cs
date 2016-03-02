using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class ListeProfilViewModel
    {
        public string NomProfilActuel { get; set; }
        public string LienProfilActuel { get; set; }
        public List<Profil> Profils { get; set; }
    }
}