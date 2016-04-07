using System;
using System.Collections.Generic;
using Projet_Serre.Models;
using System.Linq;

public class GestionProfil {
	private List<Profil> profils = new List<Profil>();
    ConnectionProfil connection = new ConnectionProfil();
    

    public GestionProfil() {
        this.profils = new List<Profil>();
	}
	public bool Ajouter(Profil profil) {
        int idProfil = connection.Ajouter(profil);

        profils.Add(profil);
        profil.Id = idProfil;

        return true;
    }
	public bool Renommer(int idProfil, string nouveauNom) {
        Profil profil = profils.Single(p => p.Id == idProfil);
        profil.Nom = nouveauNom;
        connection.Modifier(idProfil, profil);
        return true;
    }
	public bool Supprimer(int idProfil) {
        profils.Remove(profils.Single(p => p.Id == idProfil));

        connection.Supprimer(idProfil);
        return true;
    }
	public List<Profil> Lister() {
        return profils;
	}
	public Profil Selectionner(int idProfil) {
		return profils.SingleOrDefault(r => r.Id == idProfil);
    }

    public bool MajProfil()
    {
        profils = connection.ListerProfil();
        return true;
    }
}
