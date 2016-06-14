using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Projet_Serre.API_Controller
{
    public class ReglageController : ApiController
    {

        GestionProfil gp = Startup.GestionProfil;


        // GET: api/Reglage
        /*public ReglageViewModel Get()
        {

            return new string[] { "value1", "value2" };
        }*/

        // GET: api/Reglage/5
        public ListReglageViewModel Get(int id)
        {
            Profil p = gp.Selectionner(id);
            return new ListReglageViewModel(p.ListerReglage());
        }

        [Route("api/Reglage/{idProfil}/{idReglage}")]
        // GET: api/Reglage/5/6
        public ReglageViewModel Get(int idProfil, int idReglage)
        {
            try
            {
                Reglage r = gp.Selectionner(idProfil).SelectionnerReglage(idReglage);
                return new ReglageViewModel(r);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        [Route("api/Reglage/{idProfil}")]
        // POST: api/Reglage
        public void Post(int idProfil, [FromBody]string value)
        {
        }

        [Route("api/Reglage/{idProfil}/{idReglage}")]
        // PUT: api/Reglage/5/6
        public void Put(int idProfil, int idReglage, [FromBody] ReglageViewModel value)
        {

            Profil p = gp.Selectionner(idProfil);
            Reglage reglage = p.SelectionnerReglage(idReglage);
            Reglage nouveauReglage = new Reglage(value);

            reglage.TemperatureInterieur = nouveauReglage.TemperatureInterieur;
            reglage.Humidite = nouveauReglage.Humidite;
            if (nouveauReglage.Duree.Days != -1)
            {
                reglage.Duree = nouveauReglage.Duree;
            }

            if (nouveauReglage.Lumiere != -1)
            {
                reglage.Lumiere = nouveauReglage.Lumiere;
            }
            p.ModifierReglage(idReglage, reglage);
        }

        // DELETE: api/Reglage/5
        public void Delete(int id)
        {
        }
    }
}
