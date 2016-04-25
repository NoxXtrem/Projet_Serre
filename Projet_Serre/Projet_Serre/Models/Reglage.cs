using System;
using System.ComponentModel.DataAnnotations;
public class Reglage {
	private int id;
	public int Id {
		get {
			return id;
		}
        set
        {
            id = value;
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
	private double temperatureInterieur;
	public double TemperatureInterieur {
		get {
			return temperatureInterieur;
		}
		set {
			temperatureInterieur = value;
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
        
	}
	public Reglage(DateTime date, double lumiere, double temperatureInterieur, double temperatureExterieur, double humidite, double vent) {
        this.date = date;
        this.lumiere = lumiere;
        this.temperatureInterieur = temperatureInterieur;
        this.humidite = humidite;
        this.vent = vent;
    }
}
