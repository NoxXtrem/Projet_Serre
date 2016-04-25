﻿using Projet_Serre.Models;
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
                Reglage r = rs.DernierReglage ?? new Reglage();
                if (p != null)
                {
                    viewModel = new ApercuViewModel()
                    {
                        NomProfilActuel = p.Nom,
                        IdProfilActuel = p.Id,
                        TemperatureInterieurCapteur = rs.GestionCapteur.CapteurTemperatureInterieur.Valeur,
                        TemperatureExterieurCapteur = rs.GestionCapteur.CapteurTemperatureExterieur.Valeur,
                        TemperatureInterieurProfil = r.TemperatureInterieur,
                        HumiditeCapteur = rs.GestionCapteur.CapteurHumidite.Valeur,
                        HumiditeProfil = r.Humidite,
                        LumiereCapteur = rs.GestionCapteur.CapteurEnso.Valeur,
                        VentCapteur = rs.GestionCapteur.Anemometre.Valeur,
                        DateDerniereMaJ = rs.DateDernierReglage.ToString(),
                    };
                }
                else
                {
                    viewModel = new ApercuViewModel()
                    {
                        IdProfilActuel = 0,
                        TemperatureInterieurCapteur = rs.GestionCapteur.CapteurTemperatureInterieur.Valeur,
                        TemperatureExterieurCapteur = rs.GestionCapteur.CapteurTemperatureExterieur.Valeur,
                        HumiditeCapteur = rs.GestionCapteur.CapteurHumidite.Valeur,
                        LumiereCapteur = rs.GestionCapteur.CapteurEnso.Valeur,
                        VentCapteur = rs.GestionCapteur.Anemometre.Valeur,
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