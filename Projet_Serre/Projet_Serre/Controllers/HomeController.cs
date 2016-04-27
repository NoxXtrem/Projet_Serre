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
                Reglage r = rs.DernierReglage ?? rs.ProfilActuel.SelectionnerReglage(0, DateTime.Now) ?? new Reglage();
                if (rs.ProfilActuel != null)
                {
                    //TODO: Prendre les dernières valeurs des capteurs depuis la BDD
                    viewModel = new ApercuViewModel()
                    {
                        NomProfilActuel = rs.ProfilActuel.Nom,
                        IdProfilActuel = rs.ProfilActuel.Id,
                        TemperatureInterieurCapteur = 0,
                        TemperatureExterieurCapteur = 0,
                        TemperatureInterieurProfil = r.TemperatureInterieur,
                        HumiditeCapteur = 0,
                        HumiditeProfil = r.Humidite,
                        LumiereCapteur = 0,
                        VentCapteur = 0,
                        DateDerniereMaJ = rs.DateDernierReglage.ToString(),
                    };
                }
                else
                {
                    viewModel = new ApercuViewModel()
                    {
                        IdProfilActuel = 0,
                        TemperatureInterieurCapteur = 0,
                        TemperatureExterieurCapteur = 0,
                        HumiditeCapteur = 0,
                        LumiereCapteur = 0,
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