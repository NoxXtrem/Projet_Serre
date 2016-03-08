using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    public class ProfilController : Controller
    {
        RegulerSerre rs = Startup.RegulerSerre;

        // GET: Profil
        public ActionResult Index()
        {
            ListProfilViewModel viewModel;

            try
            {
                viewModel = new ListProfilViewModel()
                {
                    NomProfilActuel = rs.GestionProfil.Selectionner(rs.IdProfil).Nom,
                    LienProfilActuel = "#",
                    Profils = rs.GestionProfil.Lister() ?? new List<Profil>(),
                };
            }
            catch (Exception)
            {
                viewModel = new ListProfilViewModel()
                {
                    Profils = rs.GestionProfil.Lister() ?? new List<Profil>(),
                };
            }

            return View(viewModel);
        }

        // GET: Profil/Details/5
        public ActionResult Details(int id)
        {
            return View("Index", "Reglage", id);
        }

        // GET: Profil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profil/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Profil p = new Profil()
                    {
                        Nom = collection["Nom"],
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Profil p = new Profil()
                    {
                        Nom = collection["Nom"],
                    };
                    rs.GestionProfil.Modifier(id, p);
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
            return View();
        }

        // POST: Profil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
