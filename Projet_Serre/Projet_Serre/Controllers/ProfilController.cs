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
        RegulerSerre rs = Startup.RegulerSerre;

        // GET: Profil
        public ActionResult Index()
        {
            List<ProfilViewModel> liste = new List<ProfilViewModel>();
            rs.GestionProfil.Lister().ForEach(
                p => liste.Add(new ProfilViewModel()
                {
                    Id = p.Id,
                    Nom = p.Nom,
                })
            );
            

            ListProfilViewModel model = new ListProfilViewModel()
            {
                NomProfilActuel = (rs.ProfilActuel != null) ? rs.ProfilActuel.Nom : null,
                IdProfilActuel = (rs.ProfilActuel != null) ? rs.ProfilActuel.Id : 0,
                Profils = liste ?? new List<ProfilViewModel>(),
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
            try
            {
                if (ModelState.IsValid)
                {
                    Profil p = new Profil()
                    {
                        Nom = model.Nom,
                    };
                    rs.GestionProfil.Ajouter(p);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Profil/Edit/5
        public ActionResult Edit(int id)
        {
            Profil p = rs.GestionProfil.Selectionner(id);
            ProfilViewModel model = new ProfilViewModel()
            {
                Id = id,
                Nom = p.Nom,
            };
            return View(model);
        }

        // POST: Profil/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfilViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rs.GestionProfil.Renommer(model.Id, model.Nom);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Profil/Delete/5
        public ActionResult Delete(int id)
        {
            Profil p = rs.GestionProfil.Selectionner(id);
            ProfilViewModel model = new ProfilViewModel()
            {
                Id = id,
                Nom = p.Nom,
            };
            return View(model);
        }

        // POST: Profil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProfilViewModel model)
        {
            try
            {
                rs.GestionProfil.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Profil/Select/5
        [HttpPost]
        public ActionResult Select(int id, string date)
        {
            try
            {
                rs.ModifierProfilActuel(id, DateTime.Parse(date));
                return Content(Boolean.TrueString);
            }
            catch (Exception)
            {
                return Content(Boolean.FalseString);
            }
        }
    }
}
