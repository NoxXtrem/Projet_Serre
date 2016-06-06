using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet_Serre.API_Controller
{
    public class ReglageController : ApiController
    {

        GestionProfil gp = Startup.GestionProfil;


        // GET: api/Reglage
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }





        // GET: api/Reglage/5
        public List<Reglage> Get(int id)
        {
            Profil p = gp.Selectionner(id);
            return p.ListerReglage();
        }

        // POST: api/Reglage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reglage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reglage/5
        public void Delete(int id)
        {
        }
    }
}
