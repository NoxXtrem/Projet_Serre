using System;
using Phidgets;
using Phidgets.Events;

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

        // Ajouter code démarage phidgets

        InterfaceKit ifKit;
        ifKit = new InterfaceKit();
        //Hook the basic event handlers
        ifKit.Attach += new AttachEventHandler(ifKit_Attach);
        ifKit.Detach += new DetachEventHandler(ifKit_Detach);
        ifKit.Error += new ErrorEventHandler(ifKit_Error);
        //Hook thephidget specific event handlers
        ifKit.SensorChange += new SensorChangeEventHandler(ifKit_SensorChange);
        ifKit.open();
 

        //
        capteurEnso = new CapteurEnso();
        anemometre = new Anemometre();
        capteurTemperature = new CapteurTemp();
        capteurHumidite = new CapteurHumi();
	}

	private Capteur[] capteur;


    static void ifKit_Attach(object sender, AttachEventArgs e)
    {
        Console.WriteLine("InterfaceKit {0} attached!",
                            e.Device.SerialNumber.ToString());
    }

    //Detach event handler...Display the serial number of the detached InterfaceKit 
    //to the console
    static void ifKit_Detach(object sender, DetachEventArgs e)
    {
        Console.WriteLine("InterfaceKit {0} detached!",
                            e.Device.SerialNumber.ToString());
    }

    //Error event handler...Display the error description to the console
    static void ifKit_Error(object sender, ErrorEventArgs e)
    {
        Console.WriteLine(e.Description);
    }

    //Sensor Change event handler...Display the sensor index and it's new value to 
    //the console
    static void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
    {
        Console.WriteLine("Sensor index {0} value {1}", e.Index, e.Value);

    }
}
