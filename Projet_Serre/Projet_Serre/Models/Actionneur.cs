using System;
public class Actionneur {
	private int port;
	public int Port {
		get {
			return port;
		}
		set {
			port = value;
		}
	}
	private double commande;
	public double Commande {
		get {
			return commande;
		}
		set {
			commande = value;
		}
	}

	public Actionneur() {
		//throw new System.Exception("Not implemented");
	}


}
