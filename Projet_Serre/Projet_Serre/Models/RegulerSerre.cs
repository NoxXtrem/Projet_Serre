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

    private Reglage dernierReglage;
    public Reglage DernierReglage
    {
        get { return dernierReglage; }
        private set { dernierReglage = value; }
    }

    private DateTime dateDernierReglage;
    public DateTime DateDernierReglage
    {
        get { return dateDernierReglage; }
        private set { dateDernierReglage = value; }
    }

    private GestionCapteur gestionCapteur;
    public GestionCapteur GestionCapteur
    {
        get { return gestionCapteur; }
        private set { gestionCapteur = value; }
    }

    private GestionActionneur gestionActionneur;
    public GestionActionneur GestionActionneur
    {
        get { return gestionActionneur; }
        private set { gestionActionneur = value; }
    }

    private GestionProfil gestionProfil;
    public GestionProfil GestionProfil
    {
        get { return gestionProfil; }
        private set { gestionProfil = value; }
    }

	public RegulerSerre(GestionProfil gestionProfil) {
        this.gestionProfil = gestionProfil;
        this.gestionCapteur = new GestionCapteur();
        this.gestionActionneur = new GestionActionneur();

        idProfil = -1;
	}

	public void Reguler() {
		throw new System.Exception("Not implemented");
	}


}
