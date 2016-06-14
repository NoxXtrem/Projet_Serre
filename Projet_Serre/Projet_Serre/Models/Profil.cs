using System;
using System.Collections.Generic;
using Projet_Serre.Models;
using System.Linq;

public class Profil
{
	private int id;
    ConnectionReglage connection = new ConnectionReglage();
    public int Id
    {
		get { return id; }
        set { id = value; }
	}

    private string nom;
    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

	private List<Reglage> conditions;
    public List<Reglage> Conditions
    { 
        set { conditions = value; }
    }

	public Profil()
    {
        conditions = new List<Reglage>();
	}
	public Profil(string nom, List<Reglage> conditions) : this()
    {
        this.nom = nom;
        this.conditions = conditions;
	}

    public Profil(ProfilViewModel pvm) : this()
    {
        Id = pvm.Id;
        Nom = pvm.Nom;
    }

	public void AjouterReglage(Reglage reglage)
    {
        conditions.Add(reglage);
        reglage.Id = connection.Ajouter(reglage,id);
	}
	public void ModifierReglage(int idReglage, Reglage reglage)
    {
        Reglage temp = conditions.Single(r => r.Id == idReglage);
        temp.Humidite = reglage.Humidite;
        temp.Duree = reglage.Duree;
        temp.Lumiere = reglage.Lumiere;
        temp.TemperatureInterieur = reglage.TemperatureInterieur;
        temp.Vent = reglage.Vent;

        connection.Modifier(idReglage, reglage);
	}
	public void SupprimerReglage(int idReglage)
    {
        conditions.Remove(conditions.Single(r => r.Id == idReglage));
        connection.Supprimer(idReglage);
	}
	public List<Reglage> ListerReglage()
    {
		return conditions;
	}
	public Reglage SelectionnerReglage(int idReglage)
    {
        return conditions.SingleOrDefault(r => r.Id == idReglage);
	}
    public Reglage SelectionnerReglage(double lumiere, DateTime dateDeDebut)
    {
        //Choisir en fonction de la date puis de la lumière
        return conditions.Where(r => r.Duree >= (DateTime.Now - dateDeDebut) && r.Lumiere >= lumiere).OrderBy(r => r.Duree).ThenBy(r => r.Lumiere).FirstOrDefault();
    }
    public void MajReglage()
    {
        conditions = connection.ListerReglage();
    }
}
