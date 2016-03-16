using System;
using System.Collections.Generic;
using Projet_Serre.Models;
using System.Linq;

public class Profil {
	private int id;
    ConnectionSQL test = new ConnectionSQL();
    public int Id {
		get {
			return id;
		}
        set
        {
            id = value; 
        }
	}
	private List<Reglage> conditions;
	private string nom;
	public string Nom {
		get {
			return nom;
		}
		set {
			nom = value;
		}
	}

	public Profil() {
        conditions = new List<Reglage>();
	}
	public Profil(string nom, List<Reglage> conditions) {
        this.nom = nom;
        this.conditions = conditions;
	}
	public Reglage GetReglage(double lumiere, DateTime date) {
		throw new System.Exception("Not implemented");
	}
	public bool AjouterReglage(Reglage reglage) {
        conditions.Add(reglage);

        test.AjouterReglage(reglage,id);
        return true;
	}
	public bool ModifierReglage(int idReglage, Reglage reglage) {
        Reglage temp = conditions.Single(r => r.Id == idReglage);
        temp.Humidite = reglage.Humidite;
        temp.Date = reglage.Date;
        temp.Lumiere = reglage.Lumiere;
        temp.Temperature = reglage.Temperature;
        temp.Vent = reglage.Vent;

        test.ModifierReglage(idReglage, reglage);
        return true;
	}
	public bool SupprimerReglage(int idReglage) {
        conditions.Remove(conditions.Single(r => r.Id == idReglage));

        test.SupprimerReglage(idReglage);
        return true;
	}
	public List<Reglage> ListerReglage() {
		return conditions;
	}
	public Reglage SelectionnerReglage(int idReglage) {
        return conditions.Single(r => r.Id == idReglage);
	}
    public bool MajReglage()
    {
        conditions = test.ListerReglage();
        return true;
    }
}
