using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CT.Appllication.Interface;
using CT.Appllication.ViewModels;
using DLL;

namespace CT.API.Controllers
{
    [RoutePrefix("api")]
    public class TesteController : ApiController
    {
        private readonly IClienteAppService _clienteApp;
        
        public TesteController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet]
        [Route("dll")]
        public HttpResponseMessage GetDll()
        {
            long sum = AddClass.Add(10, 40);
            return Request.CreateResponse(HttpStatusCode.Created, sum);
        }


        [HttpGet]
        [Route("cliente")]
        public HttpResponseMessage GetClientes()
        {
            return Request.CreateResponse(HttpStatusCode.Created, _clienteApp.GetAll());
        }

        [HttpGet]
        [Route("cliente/{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _clienteApp.GetById(id));
        }

        [HttpPut]
        [Route("cliente")]
        public HttpResponseMessage Put(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApp.Update(clienteViewModel);

                return Request.CreateResponse(HttpStatusCode.Created, "Cliente atualizado com sucesso!");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPost]
        [Route("cliente")]
        public HttpResponseMessage PostClientes(ClienteViewModel cliente)
        {
            _clienteApp.Add(cliente);
            return Request.CreateResponse(HttpStatusCode.Created, cliente);
        }

        [HttpDelete]
        [Route("cliente/{id:int}")]
        public HttpResponseMessage Remove(int id)
        {
            try
            {
                _clienteApp.Remove(id);
            }
            catch (DbUpdateException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Este registro não pode ser removido.");
            }


            return Request.CreateResponse(HttpStatusCode.OK, "Dado excluído com sucesso!");
        }
    }
}
