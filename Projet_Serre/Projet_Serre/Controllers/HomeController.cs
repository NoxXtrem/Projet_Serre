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
        GestionProfil gp = Startup.GestionProfil;
        GestionProfilActuel gpa = Startup.GestionProfilActuel;

        public ActionResult Index()
        {
            ApercuViewModel viewModel;
            try
            {
                ConnectionSQL csql = new ConnectionSQL();
                LigneHistorique data = csql.DerniereEntreeHistorique();

                Profil profil = gp.Selectionner(data.Id_profil) ?? new Profil();
                Reglage reglage = profil.SelectionnerReglage(data.Id_reglage) ?? new Reglage();

                viewModel = new ApercuViewModel(gpa, data, reglage);
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