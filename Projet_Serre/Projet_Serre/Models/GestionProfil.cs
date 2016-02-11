using System;
using System.Collections.Generic;
using Projet_Serre.Models;
using System.Linq;

public class GestionProfil {
	private List<Profil> profils;

	public GestionProfil() {
        profils = new List<Profil>();
	}
	public bool Ajouter(Profil profil) {

        profils.Add(profil);
        ConnectionSQL test = new ConnectionSQL();
        test.AjouterProfil(profil);
        return true;
    }
	public bool Modifier(int idProfil, Profil profil) {
        profils.Remove(profil);
        profils.Add(profil);
        ConnectionSQL test = new ConnectionSQL();
        test.ModifierProfil(profil);
        return true;
    }
	public bool Supprimer(Profil profil) {
        profils.Remove(profil);
        ConnectionSQL test = new ConnectionSQL();
        test.SupprimerProfil(profil);
        return true;
    }
	public List<Profil> Lister() {
        return profils;
	}
	public Profil Selectionner(int idProfil) {
		return profils.Single(r => r.Id == idProfil);
    }


}
