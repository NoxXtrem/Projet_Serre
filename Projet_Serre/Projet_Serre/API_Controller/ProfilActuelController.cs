using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet_Serre.API_Controller
{
    public class ProfilActuelController : ApiController
    {

        GestionProfil gp = Startup.GestionProfil;
        
        // GET: api/ProfilActuel
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // PUT: api/ProfilActuel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProfilActuel/5
        public void Delete(int id)
        {
        }
    }
}
