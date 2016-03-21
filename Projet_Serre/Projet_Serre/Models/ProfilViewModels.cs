using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Serre.Models
{
    public class ListProfilViewModel
    {
        public string NomProfilActuel { get; set; }
        public string LienProfilActuel { get; set; }
        public List<ProfilViewModel> Profils { get; set; }
    }

    public class ProfilViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom du profil")]
        [Required(ErrorMessage = "Un nom est requis")]
        public string Nom { get; set; }
    }
}