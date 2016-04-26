using System;
using System.Threading;
public class RegulerSerre {
    private volatile bool _shouldStop;

    private Profil profilActuel;
    public Profil ProfilActuel
    {
		get {
			return profilActuel;
		}
		set {
			profilActuel = value;
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
	}

	public void Reguler() {
        while (!_shouldStop)
        {
            Console.WriteLine("worker thread: working...");

            //TODO:
            //Lire les capteurs
            double lumiereMesure = gestionCapteur.CapteurEnso.Valeur;
            //...


            if (profilActuel != null)
            {
                //Choisir le bon r�glage (modifier dernierReglage et dateDernierReglage)
                Reglage r = profilActuel.SelectionnerReglage(lumiereMesure, DateTime.Now);

                //Controller les actionneurs
                gestionActionneur.Chauffage.Commande = r.TemperatureInterieur;
                //...
            }
            

            Thread.Sleep(10000);
        }
        Console.WriteLine("worker thread: terminating gracefully."); ;
	}

    public void RegulerStop()
    {
        _shouldStop = true;
    }


}
