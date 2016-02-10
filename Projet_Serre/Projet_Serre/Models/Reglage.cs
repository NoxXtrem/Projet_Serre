using System;
public class Reglage {
	private int id;
	public int Id {
		get {
			return id;
		}
	}
	private DateTime date;
	public DateTime Date {
		get {
			return date;
		}
		set {
			date = value;
		}
	}
	private double lumiere;
	public double Lumiere {
		get {
			return lumiere;
		}
		set {
			lumiere = value;
		}
	}
	private double temperature;
	public double Temperature {
		get {
			return temperature;
		}
		set {
			temperature = value;
		}
	}
	private double humidite;
	public double Humidite {
		get {
			return humidite;
		}
		set {
			humidite = value;
		}
	}
	private double vent;
	public double Vent {
		get {
			return vent;
		}
		set {
			vent = value;
		}
	}

	public Reglage() {
		throw new System.Exception("Not implemented");
	}
	public Reglage(ref DateTime date, ref double lumiere, ref double temperature, ref double humidite, ref double vent) {
		throw new System.Exception("Not implemented");
	}


}
