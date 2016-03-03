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
                Profil p = rs.GestionProfil.Selectionner(rs.IdProfil);
                viewModel = new ApercuViewModel()
                {
                    nomProfilActuel = p.Nom,
                    lienProfilActuel = "#",
                    //temperatureCapteur = rs.GestionCapteur.CapteurTemperature.Valeur,
                    //temperatureProfil = rs.DernierReglage.Temperature,
                    //humiditeCapteur = rs.GestionCapteur.CapteurHumidite.Valeur,
                    //humiditeProfil = rs.DernierReglage.Humidite,
                    //lumiereCapteur = rs.GestionCapteur.CapteurEnso.Valeur,
                    //ventCapteur = rs.GestionCapteur.Anemometre.Valeur,
                    //dateDerniereMaJ = rs.DateDernierReglage.ToString(),
                };
            }
            catch (Exception)
            {
                viewModel = new ApercuViewModel()
                {
                    //temperatureCapteur = rs.GestionCapteur.CapteurTemperature.Valeur,
                    //humiditeCapteur = rs.GestionCapteur.CapteurHumidite.Valeur,
                    //lumiereCapteur = rs.GestionCapteur.CapteurEnso.Valeur,
                    //ventCapteur = rs.GestionCapteur.Anemometre.Valeur,
                    //dateDerniereMaJ = rs.DateDernierReglage.ToString(),
                };
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