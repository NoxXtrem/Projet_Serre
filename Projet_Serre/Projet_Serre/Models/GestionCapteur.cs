using System;
public class GestionCapteur {
	private Capteur capteurEnso;
	public Capteur CapteurEnso {
		get {
			return capteurEnso;
		}
	}

	private Capteur anemometre;
	public Capteur Anemometre {
		get {
			return anemometre;
		}
	}

	private Capteur capteurTemperatureInterieur;
    public Capteur CapteurTemperatureInterieur
    {
		get {
            return capteurTemperatureInterieur;
		}
	}

    private Capteur capteurTemperatureExterieur;
    public Capteur CapteurTemperatureExterieur
    {
        get
        {
            return capteurTemperatureExterieur;
        }
    }

	private Capteur capteurHumidite;
	public Capteur CapteurHumidite {
		get {
			return capteurHumidite;
		}
	}

	public GestionCapteur() {
        capteurEnso = new CapteurEnso();
        anemometre = new Anemometre();
        capteurTemperatureInterieur = new CapteurTemp();
        capteurTemperatureExterieur = new CapteurTemp();
        capteurHumidite = new CapteurHumi();
	}
}
