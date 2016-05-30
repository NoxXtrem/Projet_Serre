using Projet_Serre.Models;
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
            HistoriqueViewModel model = new HistoriqueViewModel(csql.EntreeHistorique(100));
            return View(model);
        }
    }
}
