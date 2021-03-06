﻿using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Serre.Controllers
{
    public class HistoriqueController : Controller
    {
        ConnectionSQL csql = new ConnectionSQL();

        // GET: Historique
        public ActionResult Index()
        {
            try
            {
                HistoriqueViewModel model = new HistoriqueViewModel(csql.EntreeHistorique(100));
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erreur : " + ex.Message);
                return View(new HistoriqueViewModel());
            }
            
        }
    }
}
