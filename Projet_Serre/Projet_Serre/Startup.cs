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

        private static Profil profil;
        public static Profil Profil
        {
            get{return Startup.profil;}
            private set{Startup.profil = value;}

        }

        private static RegulerSerre regulerSerre;
        public static RegulerSerre RegulerSerre
        {
            get { return Startup.regulerSerre; }
            private set { Startup.regulerSerre = value; }
        }
        

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            gestionProfil = new GestionProfil();
            regulerSerre = new RegulerSerre(gestionProfil);

            profil = new Profil("Test", new System.Collections.Generic.List<Reglage>());
            gestionProfil.Ajouter(profil);
            profil.AjouterReglage(new Reglage(DateTime.Today, 100, 20.5, 50, 2));

            gestionProfil.MajProfil();
            profil.MajReglage();

            Thread regulerThread = new Thread(regulerSerre.Reguler);
            regulerThread.Start();
            System.Console.WriteLine("main thread: Starting worker thread...");

        }


    }
}
