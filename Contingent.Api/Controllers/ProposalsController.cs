using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contingent.Api.Models;

namespace Contingent.Api.Controllers
{
    [RoutePrefix("api/proposals")]
    public class ProposalsController : ApiController
    {
        private static List<Proposal> _data = new List<Proposal>();

        [Route]
        public Proposal[] Get()
        {
            return _data.ToArray();
        }

        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var result = _data.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Proposal not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route]
        public HttpResponseMessage Post(Proposal data)
        {
            if (data.Actions == null || data.Actions.Count == 0)
            {
                throw new ArgumentException("New proposal must containt at least one action");
            }

            data.Id = _data.Max(p => p.Id) + 1;
            _data.Add(data);

            return Request.CreateResponse(HttpStatusCode.Created, data);
        }
    }
}
