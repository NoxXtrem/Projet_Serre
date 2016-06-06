using Projet_Serre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet_Serre.API_Controller
{
    public class CapteurController : ApiController
    {

        GestionProfil gp = Startup.GestionProfil;
        ConnectionSQL csql = new ConnectionSQL();

        // GET: api/Capteur
        public LigneHistorique Get()
        {
            return csql.DerniereEntreeHistorique();
        }

        // GET: api/Capteur/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Capteur
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Capteur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Capteur/5
        public void Delete(int id)
        {
        }
    }
}
