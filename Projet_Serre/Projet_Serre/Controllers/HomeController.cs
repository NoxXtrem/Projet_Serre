using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    public class HomeController : Controller
    {
        RegulerSerre rs = Startup.RegulerSerre;

        public ActionResult Index()
        {
            ApercuViewModel viewModel;
            try
            {
                //TODO: Récupérer le dernier réglage + date de début dans la BDD
                ConnectionSQL csql = new ConnectionSQL();
                LigneHistorique data = csql.DerniereEntreeHistorique();

                Reglage r = new Reglage();
                try
                {
                    r = rs.GestionProfil.Lister().SelectMany(p => p.ListerReglage()).Select(re => re.Id == data.Id_reglage);
                }
                catch (Exception)
                {
                }
                if (rs.ProfilActuel != null)
                {
                    //TODO: Prendre les dernières valeurs des capteurs depuis la BDD
                    viewModel = new ApercuViewModel()
                    {
                        NomProfilActuel = rs.ProfilActuel.Nom,
                        IdProfilActuel = rs.ProfilActuel.Id,
                        TemperatureInterieurCapteur = data.TemperatureInterieur,
                        TemperatureExterieurCapteur = data.TemperatureExterieur,
                        TemperatureInterieurProfil = r.TemperatureInterieur,
                        HumiditeCapteur = data.Humidite,
                        HumiditeProfil = r.Humidite,
                        LumiereCapteur = data.Lumiere,
                        VentCapteur = 0,
                        DateDerniereMaJ = rs.DateDernierReglage.ToString(),
                    };
                }
                else
                {
                    viewModel = new ApercuViewModel()
                    {
                        IdProfilActuel = 0,
                        TemperatureInterieurCapteur = data.TemperatureInterieur,
                        TemperatureExterieurCapteur = data.TemperatureExterieur,
                        HumiditeCapteur = data.Humidite,
                        LumiereCapteur = data.Lumiere,
                        VentCapteur = 0,
                        DateDerniereMaJ = rs.DateDernierReglage.ToString(),
                    };
                }
            }
            catch (Exception)
            {
                viewModel = new ApercuViewModel();
            }
            
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}