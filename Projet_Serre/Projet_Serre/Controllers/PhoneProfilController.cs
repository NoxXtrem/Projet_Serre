using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet_Serre.API
{
    public class PhoneProfilController : ApiController
    {

        RegulerSerre rs = Startup.RegulerSerre;

        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<Profil> lp = rs.GestionProfil.Lister();

            return Request.CreateResponse<List<Profil>>(HttpStatusCode.OK, lp);
        }







    }
}
