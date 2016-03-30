using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    //TODO: Un selecteur de date pour le champ Date
    //TODO: Définir des limites pour les champs de type double? (positif, maximum, etc)
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
                    IdReglage = r.Id,
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
                    Profil p = rs.GestionProfil.Selectionner(id);
                    Reglage r = new Reglage()
                    {
                        Date = DateTime.Parse(model.Date),
                        Lumiere = model.Lumiere,
                        Temperature = model.Temperature,
                        Humidite = model.Humidite,
                    };
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
            Profil profil = rs.GestionProfil.Lister().SingleOrDefault(p => p.ListerReglage().Exists(r => r.Id == id));
            Reglage reglage = rs.GestionProfil.Lister().SelectMany(p => p.ListerReglage()).SingleOrDefault(r => r.Id == id);    //TODO: Meilleur façon de faire ça?
            ReglageViewModel model = new ReglageViewModel()
            {
                IdReglage = id,
                IdProfil = profil.Id,
                Date = reglage.Date.ToShortDateString(),
                Lumiere = reglage.Lumiere,
                Temperature = reglage.Temperature,
                Humidite = reglage.Humidite,
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
                    Profil profil = rs.GestionProfil.Lister().Single(p => p.ListerReglage().Exists(r => r.Id == id));   //TODO: Meilleur façon de faire ça?
                    Reglage reglage = new Reglage()
                    {
                        Id = model.IdReglage,
                        Date = DateTime.Parse(model.Date),
                        Lumiere = model.Lumiere,
                        Temperature = model.Temperature,
                        Humidite = model.Humidite,
                    };
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
            Profil profil = rs.GestionProfil.Lister().SingleOrDefault(p => p.ListerReglage().Exists(r => r.Id == id));
            Reglage reglage = rs.GestionProfil.Lister().SelectMany(p => p.ListerReglage()).SingleOrDefault(r => r.Id == id);    //TODO: Meilleur façon de faire ça?
            ReglageViewModel model = new ReglageViewModel()
            {
                IdReglage = id,
                IdProfil = profil.Id,
                Date = reglage.Date.ToShortDateString(),
                Lumiere = reglage.Lumiere,
                Temperature = reglage.Temperature,
                Humidite = reglage.Humidite,
            };

            return View(model);
        }

        // POST: Reglage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReglageViewModel model)
        {
            try
            {
                Profil profil = rs.GestionProfil.Lister().Single(p => p.ListerReglage().Exists(r => r.Id == id));   //TODO: Meilleur façon de faire ça?
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
