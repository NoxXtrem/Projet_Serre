using System;
public class Profil {
	private int id;
	public int Id {
		get {
			return id;
		}
	}
	private Reglage[] conditions;
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
		throw new System.Exception("Not implemented");
	}
	public Profil(ref string nom, ref Reglage[] conditions) {
		throw new System.Exception("Not implemented");
	}
	public Reglage GetReglage(ref double lumiere, ref DateTime date) {
		throw new System.Exception("Not implemented");
	}
	public bool AjouterReglage(ref Reglage reglage) {
		throw new System.Exception("Not implemented");
	}
	public bool ModifierReglage(ref int idReglage, ref Reglage reglage) {
		throw new System.Exception("Not implemented");
	}
	public bool SupprimerReglage(ref int idReglage) {
		throw new System.Exception("Not implemented");
	}
	public Reglage[] ListerReglage() {
		throw new System.Exception("Not implemented");
	}
	public Reglage SelectionnerReglage(ref int idReglage) {
		throw new System.Exception("Not implemented");
	}

	private Reglage[] reglages;


}
