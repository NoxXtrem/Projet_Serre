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
        public int IdProfilActuel { get; set; }
        public int NombreDeJours { get; set; }
        public List<ProfilViewModel> Profils { get; set; }

        public ListProfilViewModel() { }
        public ListProfilViewModel(List<Profil> list)
        {
            Profils = new List<ProfilViewModel>();
            list.ForEach(p => Profils.Add(new ProfilViewModel(p)));
        }
    }

    public class ProfilViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom du profil")]
        [Required(ErrorMessage = "Un nom est requis")]
        public string Nom { get; set; }

        public ProfilViewModel() { }
        public ProfilViewModel(Profil p)
        {
            Id = p.Id;
            Nom = p.Nom;
        }
    }
}