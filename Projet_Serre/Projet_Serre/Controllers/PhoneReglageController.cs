using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet_Serre.API
{
    public class PhoneReglageController : ApiController
    {
        RegulerSerre rs = Startup.RegulerSerre;

        public HttpResponseMessage GetReglage(Profil p)
        {
            List<Reglage> lr = p.ListerReglage();

            return Request.CreateResponse<List<Reglage>>(HttpStatusCode.OK, lr);
        }

    }
}
