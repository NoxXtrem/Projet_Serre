using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    //TODO: Gestion des erreurs
    //TODO: Validation coté client (jQuery)
    public class ProfilController : Controller
    {
        GestionProfil gp = Startup.GestionProfil;
        GestionProfilActuel gpa = Startup.GestionProfilActuel;

        // GET: Profil
        public ActionResult Index()
        {
            ListProfilViewModel model = new ListProfilViewModel(gp.Lister())
            {
                NomProfilActuel = (gpa.ProfilActuel != null) ? gpa.ProfilActuel.Nom : null,
                IdProfilActuel = (gpa.ProfilActuel != null) ? gpa.ProfilActuel.Id : 0,
                NombreDeJours = (DateTime.Now - gpa.DateDeDebut).Days,
            };
            return View(model);
        }

        // GET: Profil/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "Reglage", new { id });
        }

        // GET: Profil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profil/Create
        [HttpPost]
        public ActionResult Create(ProfilViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Profil p = new Profil(model);
                    gp.Ajouter(p);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Erreur : " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Profil/Edit/5
        public ActionResult Edit(int id)
        {
            Profil p = gp.Selectionner(id);
            ProfilViewModel model = new ProfilViewModel(p);
            return View(model);
        }

        // POST: Profil/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfilViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    gp.Renommer(model.Id, model.Nom);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Erreur : " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Profil/Delete/5
        public ActionResult Delete(int id)
        {
            Profil p = gp.Selectionner(id);
            ProfilViewModel model = new ProfilViewModel(p);
            return View(model);
        }

        // POST: Profil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProfilViewModel model)
        {
            try
            {
                gp.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Erreur : " + ex.Message);
                return View(ex.Message);
            }
        }

        // POST: Profil/Select/5
        [HttpPost]
        public ActionResult Select(int id, string date)
        {
            try
            {
                gpa.ModifierProfilActuel(id, DateTime.Parse(date));
                return Content(Boolean.TrueString);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erreur : " + ex.Message);
                return Content(Boolean.FalseString);
            }
        }

        // POST: Profil/Stop/5
        [HttpPost]
        public ActionResult Stop()
        {
            try
            {
                gpa.ModifierProfilActuel(0, new DateTime());
                return Content(Boolean.TrueString);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erreur : " + ex.Message);
                return Content(Boolean.FalseString);
            }
        }
    }
}
