using System;
public class Capteur {
	private int port;
	public int Port {
		get {
			return port;
		}
		set {
			port = value;
		}
	}
	private double valeur;
	public double Valeur {
		get {

            // récupération valeur phidget
			return valeur;
		}
	}

	public Capteur() {
		//throw new System.Exception("Not implemented");
	}


}
