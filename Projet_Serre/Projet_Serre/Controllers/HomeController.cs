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
                ConnectionSQL csql = new ConnectionSQL();
                LigneHistorique data = csql.DerniereEntreeHistorique();

                Profil profil = rs.GestionProfil.Selectionner(data.Id_profil) ?? new Profil();
                Reglage reglage = profil.SelectionnerReglage(data.Id_reglage) ?? new Reglage();
                //Reglage reglage = rs.GestionProfil.Lister().SelectMany(p => p.ListerReglage()).SingleOrDefault(re => re.Id == data.Id_reglage) ?? new Reglage();
                
                if (rs.ProfilActuel != null)
                {
                    viewModel = new ApercuViewModel()
                    {
                        NomProfilActuel = rs.ProfilActuel.Nom,
                        IdProfilActuel = rs.ProfilActuel.Id,
                        NombreDeJours = (DateTime.Now - rs.DateDeDebut).Days,
                        TemperatureInterieurCapteur = data.TemperatureInterieur,
                        TemperatureExterieurCapteur = data.TemperatureExterieur,
                        TemperatureInterieurProfil = reglage.TemperatureInterieur,
                        HumiditeCapteur = data.Humidite,
                        HumiditeProfil = reglage.Humidite,
                        LumiereCapteur = data.Lumiere,
                        VentCapteur = 0,
                        DateDerniereMaJ = data.Date.ToString(),
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