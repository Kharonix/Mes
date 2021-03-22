using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Mes.Controllers.Api.V1
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WebApiController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            return "Test";

        }
    }
}
