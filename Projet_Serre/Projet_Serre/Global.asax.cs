using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Projet_Serre
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static GestionProfil gestionProfil;
        public static GestionProfil GestionProfil
        {
            get { return gestionProfil; }
            private set { gestionProfil = value; }
        }

        private static Profil profil;
        public static Profil Profil
        {
            get { return profil; }
            private set { profil = value; }

        }

        private static RegulerSerre regulerSerre;
        public static RegulerSerre RegulerSerre
        {
            get { return regulerSerre; }
            private set { regulerSerre = value; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            gestionProfil = new GestionProfil();
            regulerSerre = new RegulerSerre(gestionProfil);

            // profil = new Profil("Test", new System.Collections.Generic.List<Reglage>());
            // gestionProfil.Ajouter(profil);
            // profil.AjouterReglage(new Reglage(DateTime.Today, 100, 20.5, 50, 2));

            gestionProfil.MajProfil();
            //profil.MajReglage();

            Thread regulerThread = new Thread(regulerSerre.Reguler);
            regulerThread.Start();
            System.Console.WriteLine("main thread: Starting worker thread...");
        }
    }
}
