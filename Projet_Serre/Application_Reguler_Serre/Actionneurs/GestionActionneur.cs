using System;
public class GestionActionneur {
	private Actionneur extracteur;
	public Actionneur Extracteur {
		get {
			return extracteur;
		}
	}
	private Actionneur trappe;
	public Actionneur Trappe {
		get {
			return trappe;
		}
	}
	private Actionneur chauffage;
	public Actionneur Chauffage {
		get {
			return chauffage;
		}
	}
	private Actionneur vannes;
	public Actionneur Vannes {
		get {
			return vannes;
		}
	}

	public GestionActionneur() {
        extracteur = new Extracteurs();
        trappe = new Trappe();
        chauffage = new Chauffage();
        vannes = new Vannes();
	}
}
