using Projet_Serre;
using Projet_Serre.Models;
using System;
using System.Threading;
public class RegulerSerre {
    private volatile bool _shouldStop;
    GestionProfil gp = Startup.GestionProfil;
    ConnectionSQL csql = new ConnectionSQL();

    private Profil profilActuel;
    public Profil ProfilActuel
    {
		get {
			return profilActuel;
		}
		private set {
			profilActuel = value;
		}
	}

    private DateTime dateDeDebut;
    public DateTime DateDeDebut
    {
        get { return dateDeDebut; }
        private set { dateDeDebut = value; }
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

    private GestionProfil gestionProfil;
    public GestionProfil GestionProfil
    {
        get { return gestionProfil; }
        private set { gestionProfil = value; }
    }

	public RegulerSerre(GestionProfil gestionProfil) {
        this.gestionProfil = gestionProfil;
	}

	public void Reguler() {
        while (!_shouldStop)
        {
            Console.WriteLine("worker thread: working...");

            //TODO:
            //Lire les capteurs
            //double lumiereMesure = gestionCapteur.CapteurEnso.Valeur;
            //...


            if (profilActuel != null)
            {
                //Choisir le bon réglage (modifier dernierReglage et dateDernierReglage)
                //Reglage r = profilActuel.SelectionnerReglage(lumiereMesure, DateTime.Now);

                //Controller les actionneurs
                //gestionActionneur.Chauffage.Commande = r.TemperatureInterieur;
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

    public void MajProfilActuel()
    {
        profilActuel = gp.Selectionner(csql.Profil_Actuel_Id());
        dateDeDebut = csql.Profil_Actuel_Date();
    }

    public void ModifierProfilActuel(int idProfil, DateTime DateDeDebut)
    {
        profilActuel = gp.Selectionner(idProfil);
        dateDeDebut = DateDeDebut;
        csql.Modifier_Profil_Actuel(idProfil, dateDeDebut);
    }
}
