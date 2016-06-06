using Projet_Serre;
using Projet_Serre.Models;
using System;
using System.Threading;
public class GestionProfilActuel {
    GestionProfil gp = Startup.GestionProfil;
    ConnectionSQL csql = new ConnectionSQL();

    private Profil profilActuel;
    public Profil ProfilActuel
    {
		get { return profilActuel; }
		private set { profilActuel = value; }
	}

    private DateTime dateDeDebut;
    public DateTime DateDeDebut
    {
        get { return dateDeDebut; }
        private set { dateDeDebut = value; }
    }

    public void MajProfilActuel()
    {
        profilActuel = gp.Selectionner(csql.Profil_Actuel_Id());
        dateDeDebut = csql.Profil_Actuel_Date();
    }

    public void ModifierProfilActuel(int idProfil, DateTime date)
    {
        profilActuel = gp.Selectionner(idProfil);
        dateDeDebut = date;
        csql.Modifier_Profil_Actuel(idProfil, dateDeDebut);
    }
}
