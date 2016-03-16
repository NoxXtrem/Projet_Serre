using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    public class ReglageController : Controller
    {
        RegulerSerre rs = Startup.RegulerSerre;

        // GET: Reglage/5
        public ActionResult Index(int id)
        {
            Profil p = rs.GestionProfil.Selectionner(id);
            List<ReglageViewModel> liste = new List<ReglageViewModel>();
            p.ListerReglage().ForEach(r => liste.Add(new ReglageViewModel()
                {
                    Date = r.Date.ToShortDateString(),
                    Id = r.Id,
                    Lumiere = r.Lumiere,
                    Temperature = r.Temperature,
                    Humidite = r.Humidite,
                })
            );

            ListReglageViewModel model = new ListReglageViewModel(){
                IdProfil = id,
                NomProfil = p.Nom,
                Reglages = liste,
            };
            return View(model);
        }

        // GET: Reglage/Details/5
        public ActionResult Details(int idReglage)
        {
            return View();
        }

        // GET: Reglage/Create/5
        public ActionResult Create(int idProfil)
        {
            return View();
        }

        // POST: Reglage/Create/5
        [HttpPost]
        public ActionResult Create(int idProfil, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reglage/Edit/5
        public ActionResult Edit(int idReglage)
        {
            return View();
        }

        // POST: Reglage/Edit/5
        [HttpPost]
        public ActionResult Edit(int idReglage, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reglage/Delete/5
        public ActionResult Delete(int idReglage)
        {
            return View();
        }

        // POST: Reglage/Delete/5
        [HttpPost]
        public ActionResult Delete(int idReglage, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
