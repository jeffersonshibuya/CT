using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CT.Appllication.Interface;
using CT.Appllication.ViewModels;

namespace CT.API.Controllers
{
    [RoutePrefix("api")]
    public class EntProjetosController : ApiController
    {
        private readonly IEntProjetosAppService _entProjetosApp;

        public EntProjetosController(IEntProjetosAppService entProjetosApp)
        {
            _entProjetosApp = entProjetosApp;
        }

        [HttpGet]
        [Route("projetos/entidade/{idEntidade:int}")]
        public HttpResponseMessage GetByEntidade(int idEntidade)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _entProjetosApp.GetByEntidade(idEntidade));
        }

        [HttpGet]
        [Route("projetos")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Created, _entProjetosApp.GetAll());
        }

        [HttpPost]
        [Route("projetos")]
        public HttpResponseMessage Post(EntProjetosViewModel projeto)
        {
            if (ModelState.IsValid)
            {
                _entProjetosApp.Add(projeto);
                return Request.CreateResponse(HttpStatusCode.Created, projeto);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("projetos")]
        public HttpResponseMessage Put(EntProjetosViewModel projeto)
        {
            if (ModelState.IsValid)
            {
                _entProjetosApp.Update(projeto);
                return Request.CreateResponse(HttpStatusCode.Created, projeto);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
