using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet_Serre.API_Controller
{
    public class ProfilController : ApiController
    {
        GestionProfil gp = Startup.GestionProfil;

        // GET: api/Profil
        public List<Profil> Get()
        {
            return gp.Lister();
        }

        // GET: api/Profil/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profil
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profil/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profil/5
        public void Delete(int id)
        {
        }
    }
}

