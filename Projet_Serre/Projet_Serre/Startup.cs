using Microsoft.Owin;
using Owin;
using System;
using System.Threading;

[assembly: OwinStartupAttribute(typeof(Projet_Serre.Startup))]
namespace Projet_Serre
{
    public partial class Startup
    {
        private static GestionProfil gestionProfil;
        public static GestionProfil GestionProfil
        {
            get { return Startup.gestionProfil; }
            private set { Startup.gestionProfil = value; }
        }

        private static GestionProfilActuel gestionProfilActuel;
        public static GestionProfilActuel GestionProfilActuel
        {
            get { return Startup.gestionProfilActuel; }
            private set { Startup.gestionProfilActuel = value; }
        }
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            gestionProfil = new GestionProfil();
            gestionProfilActuel = new GestionProfilActuel();

           // profil = new Profil("Test", new System.Collections.Generic.List<Reglage>());
           // gestionProfil.Ajouter(profil);
           // profil.AjouterReglage(new Reglage(DateTime.Today, 100, 20.5, 50, 2));

            gestionProfil.MajProfil();
            gestionProfilActuel.MajProfilActuel();
        }
    }
}
