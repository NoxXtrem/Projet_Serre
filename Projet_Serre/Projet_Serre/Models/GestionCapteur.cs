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
	private Capteur capteurTemperature;
	public Capteur CapteurTemperature {
		get {
			return capteurTemperature;
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
        capteurTemperature = new CapteurTemp();
        capteurHumidite = new CapteurHumi();
	}

	private Capteur[] capteur;

}
