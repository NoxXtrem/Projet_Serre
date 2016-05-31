using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    //TODO: Définir des limites pour les champs de type double? (positif, maximum, etc)
    public class ReglageController : Controller
    {
        GestionProfil gp = Startup.GestionProfil;

        // GET: Reglage/5
        public ActionResult Index(int id)
        {
            Profil p = gp.Selectionner(id);
            ListReglageViewModel model = new ListReglageViewModel(p.ListerReglage())
            {
                IdProfil = id,
                NomProfil = p.Nom,
            };
            return View(model);
        }

        // GET: Reglage/Details/5
        public ActionResult Details(int idReglage)
        {
            return View();
        }

        // GET: Reglage/Create/5
        public ActionResult Create(int id)
        {
            ReglageViewModel model = new ReglageViewModel()
            {
                IdProfil = id,
            };
            return View(model);
        }

        // POST: Reglage/Create/5
        [HttpPost]
        public ActionResult Create(int id, ReglageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Profil p = gp.Selectionner(id);
                    Reglage r = new Reglage(model);
                    p.AjouterReglage(r);
                    return RedirectToAction("Index",  new { id });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reglage/Edit/5
        public ActionResult Edit(int id)
        {
            Profil profil = gp.Lister().SingleOrDefault(p => p.ListerReglage().Exists(r => r.Id == id));
            Reglage reglage = gp.Lister().SelectMany(p => p.ListerReglage()).SingleOrDefault(r => r.Id == id);    //TODO: Meilleur façon de faire ça?
            ReglageViewModel model = new ReglageViewModel(reglage)
            {
                IdProfil = profil.Id,
            };

            return View(model);
        }

        // POST: Reglage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReglageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Profil profil = gp.Lister().Single(p => p.ListerReglage().Exists(r => r.Id == id));   //TODO: Meilleur façon de faire ça?
                    Reglage reglage = new Reglage(model);
                    profil.ModifierReglage(id, reglage);
                    return RedirectToAction("Index", new { profil.Id });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reglage/Delete/5
        public ActionResult Delete(int id)
        {
            Profil profil = gp.Lister().SingleOrDefault(p => p.ListerReglage().Exists(r => r.Id == id));
            Reglage reglage = gp.Lister().SelectMany(p => p.ListerReglage()).SingleOrDefault(r => r.Id == id);    //TODO: Meilleur façon de faire ça?
            ReglageViewModel model = new ReglageViewModel(reglage)
            {
                IdProfil = profil.Id,
            };

            return View(model);
        }

        // POST: Reglage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReglageViewModel model)
        {
            try
            {
                Profil profil = gp.Lister().Single(p => p.ListerReglage().Exists(r => r.Id == id));   //TODO: Meilleur façon de faire ça?
                profil.SupprimerReglage(id);
                return RedirectToAction("Index", new { profil.Id });
            }
            catch
            {
                return View(model);
            }
        }
    }
}
