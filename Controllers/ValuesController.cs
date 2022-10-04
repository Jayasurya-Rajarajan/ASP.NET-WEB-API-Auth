using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using BasicAuth.Models;

namespace BasicAuth.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            using(AuthPracticeEntities entities = new AuthPracticeEntities())
            {
                if (username.ToLower() == "male")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(p => p.Gender.ToLower() == "male").ToList());
                }
                else if(username.ToLower() == "female")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(p => p.Gender.ToLower() == "female").ToList());
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
        }

        // GET api/values/5
        

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
