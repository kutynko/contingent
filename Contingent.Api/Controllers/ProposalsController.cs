using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contingent.Api.Controllers
{
    [RoutePrefix("api/proposals")]
    public class ProposalsController : ApiController
    {
        [Route]
        public IEnumerable<string> Get()
        {
            return new[] { "foo", "bar" };
        }
    }
}
