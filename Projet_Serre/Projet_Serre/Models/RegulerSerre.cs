using System;
public class RegulerSerre {
	private int idProfil;
	public int IdProfil {
		get {
			return idProfil;
		}
		set {
			idProfil = value;
		}
	}
	private GestionCapteur gestionCapteur;
	private GestionActionneur gestionActionneur;
	private GestionProfil gestionProfil;

	public RegulerSerre(ref GestionProfil gestionProfil) {
		throw new System.Exception("Not implemented");
	}
	public void Reguler() {
		throw new System.Exception("Not implemented");
	}


}
