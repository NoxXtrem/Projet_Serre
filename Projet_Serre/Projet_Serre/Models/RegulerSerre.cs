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

	public RegulerSerre(GestionProfil gestionProfil) {
        this.gestionProfil = gestionProfil;
        this.gestionCapteur = new GestionCapteur();
        this.gestionActionneur = new GestionActionneur();
	}
	public void Reguler() {
		throw new System.Exception("Not implemented");
	}


}
