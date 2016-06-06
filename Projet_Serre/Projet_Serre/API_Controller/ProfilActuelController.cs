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
    public class ProfilActuelController : ApiController
    {

        GestionProfil gp = Startup.GestionProfil;
        GestionProfilActuel gpa = Startup.GestionProfilActuel;
        
        // GET: api/ProfilActuel
        public Object Get()
        {

            return new { profil = (gpa.ProfilActuel != null) ? new ProfilViewModel(gpa.ProfilActuel) : null, date = gpa.DateDeDebut.ToString() };
        }

        // GET: api/ProfilActuel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProfilActuel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProfilActuel
        public void Put([FromBody]string id, [FromBody]string date)
        {
            DateTime dt = DateTime.Parse(date);
            int idProfil = int.Parse(id);
            gpa.ModifierProfilActuel(idProfil, dt);

        }

        // DELETE: api/ProfilActuel/5
        public void Delete(int id)
        {
        }
    }
}
