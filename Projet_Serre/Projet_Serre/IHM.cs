using System;
public class IHM {
	private GestionProfil gestionProfil;
	private RegulerSerre regulerSerre;

	public bool AjouterProfil(ref Profil profil) {
		throw new System.Exception("Not implemented");
	}
	public bool ModifierProfil(ref int idProfil, ref Profil profil) {
		throw new System.Exception("Not implemented");
	}
	public bool SupprimerProfil(ref int idProfil) {
		throw new System.Exception("Not implemented");
	}
	public Profil[] ListerProfil() {
		throw new System.Exception("Not implemented");
	}
	public void ChosirProfil(ref int idProfil) {
		throw new System.Exception("Not implemented");
	}
	public bool AjouterReglage(ref Profil profil, ref Reglage reglage) {
		throw new System.Exception("Not implemented");
	}
	public bool ModifierReglage(ref Profil profil, ref int idReglage, ref Reglage reglage) {
		throw new System.Exception("Not implemented");
	}
	public bool SupprimerReglage(ref Profil profil, ref int idReglage) {
		throw new System.Exception("Not implemented");
	}
	public Reglage[] ListerReglage(ref Profil profil) {
		throw new System.Exception("Not implemented");
	}

}
