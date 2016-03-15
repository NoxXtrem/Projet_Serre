﻿using Microsoft.Owin;
using Owin;
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
            gestionProfil.MajProfil();
            Thread regulerThread = new Thread(regulerSerre.Reguler);

            //regulerThread.Start();
            //System.Console.WriteLine("main thread: Starting worker thread...");

        }


    }
}
