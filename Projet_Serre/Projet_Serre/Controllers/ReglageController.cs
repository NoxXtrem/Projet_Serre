using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    public class ReglageController : Controller
    {
        GestionProfil gp = Startup.GestionProfil;

        // GET: Reglage/5
        public ActionResult Index(int id)
        {
            Profil p = gp.Selectionner(id);
            if (p != null)
            {
                ListReglageViewModel model = new ListReglageViewModel(p.ListerReglage(), id)
                {
                    NomProfil = p.Nom,
                };
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Reglage/Details/5
        public ActionResult Details(int idReglage)
        {
            return View();
        }

        // GET: Reglage/Create/5
        public ActionResult Create(int id)
        {
            if (gp.Selectionner(id) != null)
            {
                ReglageViewModel model = new ReglageViewModel()
                {
                    IdProfil = id,
                };
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Reglage/Create/5
        [HttpPost]
        public ActionResult Create(int id, ReglageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Profil p = gp.Selectionner(id);
                    Reglage r = new Reglage(model);
                    p.AjouterReglage(r);
                    return RedirectToAction("Index", new { id });
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Erreur : " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Reglage/Edit/5
        public ActionResult Edit(int id, int idProfil)
        {
            Profil profil;
            Reglage reglage;
            if ((profil = gp.Selectionner(idProfil)) != null && (reglage = profil.SelectionnerReglage(id)) != null)
            {
                ReglageViewModel model = new ReglageViewModel(reglage, idProfil);
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Reglage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReglageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Profil profil = gp.Lister().Single(p => p.ListerReglage().Exists(r => r.Id == id));   //TODO: Meilleur façon de faire ça?
                    Reglage reglage = new Reglage(model);
                    profil.ModifierReglage(id, reglage);
                    return RedirectToAction("Index", new { profil.Id });

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Erreur : " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Reglage/Delete/5
        public ActionResult Delete(int id, int idProfil)
        {
            Profil profil;
            Reglage reglage;
            if ((profil = gp.Selectionner(idProfil)) != null && (reglage = profil.SelectionnerReglage(id)) != null)
            {
                ReglageViewModel model = new ReglageViewModel(reglage, idProfil);
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
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
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Erreur : " + ex.Message);
                return View(model);
            }
        }
    }
}
