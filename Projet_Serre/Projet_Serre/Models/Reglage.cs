using Projet_Serre.Models;
using System;
using System.ComponentModel.DataAnnotations;
public class Reglage {
	private int id;
	public int Id {
		get { return id; }
        set { id = value; }
    }

	private TimeSpan duree;
    public TimeSpan Duree
    {
		get { return duree; }
		set { duree = value; }
	}

	private double lumiere;
	public double Lumiere {
		get { return lumiere; }
		set { lumiere = value; }
	}

	private double temperatureInterieur;
	public double TemperatureInterieur {
		get { return temperatureInterieur; }
		set { temperatureInterieur = value; }
	}

    private double humidite;
	public double Humidite {
		get { return humidite; }
		set { humidite = value; }
	}

	private double vent;
	public double Vent {
		get { return vent; }
		set { vent = value; }
	}

    public Reglage() { }

	public Reglage(TimeSpan date, double lumiere, double temperatureInterieur, double temperatureExterieur, double humidite, double vent) {
        this.duree = date;
        this.lumiere = lumiere;
        this.temperatureInterieur = temperatureInterieur;
        this.humidite = humidite;
        this.vent = vent;
    }
    
    public Reglage(ReglageViewModel rvm){
        Id = rvm.IdReglage;
        Duree = new TimeSpan(rvm.Duree, 0, 0, 0);
        Lumiere = Math.Round(rvm.Lumiere, 2);
        TemperatureInterieur = Math.Round(rvm.TemperatureInterieur, 2);
        Humidite = Math.Round(rvm.Humidite, 2);
    }
}
