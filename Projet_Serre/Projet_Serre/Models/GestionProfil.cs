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

	public void Ajouter(Profil profil) {
        int idProfil = connection.Ajouter(profil);
        profils.Add(profil);
        profil.Id = idProfil;
    }

	public void Renommer(int idProfil, string nouveauNom) {
        Profil profil = profils.Single(p => p.Id == idProfil);
        profil.Nom = nouveauNom;
        connection.Modifier(idProfil, profil);
    }

	public void Supprimer(int idProfil) {
        profils.Remove(profils.Single(p => p.Id == idProfil));
        connection.Supprimer(idProfil);
    }

	public List<Profil> Lister() {
        return profils;
	}

	public Profil Selectionner(int idProfil) {
        if (idProfil != 0)
        {
            return profils.SingleOrDefault(r => r.Id == idProfil);
        }
        else
        {
            return null;
        }
    }

    public void MajProfil()
    {
        profils = connection.ListerProfil();
    }
}
