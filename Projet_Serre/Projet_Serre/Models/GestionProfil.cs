using System;
using System.Collections.Generic;
using Projet_Serre.Models;
using System.Linq;

public class GestionProfil {
	private List<Profil> profils;
    ConnectionSQL test = new ConnectionSQL();

    public GestionProfil() {
        profils = new List<Profil>();

        profils.Add(new Profil("Radis", new List<Reglage>()){ Id = -1});
	}
	public bool Ajouter(Profil profil) {
        int idProfil = test.AjouterProfil(profil);

        profils.Add(profil);
        profil.Id = idProfil;

        return true;
    }
	public bool Modifier(int idProfil, Profil profil) {
        profils.Remove(profil);
        profils.Add(profil);

        test.ModifierProfil(profil);
        return true;
    }
	public bool Supprimer(int idProfil) {
        profils.Remove(profils.Single(p => p.Id == idProfil));

        test.SupprimerProfil(idProfil);
        return true;
    }
	public List<Profil> Lister() {
        return profils;
	}
	public Profil Selectionner(int idProfil) {
		return profils.Single(r => r.Id == idProfil);
    }
}
