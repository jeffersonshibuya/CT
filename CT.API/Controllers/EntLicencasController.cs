using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CT.Appllication.Interface;

namespace CT.API.Controllers
{
    [RoutePrefix("api")]
    public class EntLicencasController : ApiController
    {
        private readonly IEntLicencasAppService _entLicencasApp;

        public EntLicencasController(IEntLicencasAppService entLicencasApp)
        {
            _entLicencasApp = entLicencasApp;
        }

        [HttpGet]
        [Route("licencas")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Created, _entLicencasApp.GetAll());
        }
    }
}
