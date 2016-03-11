using CT.Appllication.Interface;
using CT.Appllication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CT.API.Controllers
{
    [RoutePrefix("api")]
    public class EntidadeController : ApiController
    {
        private readonly IEntidadesAppService _entidadesApp;

        public EntidadeController(IEntidadesAppService entidadeApp)
        {
            _entidadesApp = entidadeApp;
        }

        [Route("paged")]
        public EntidadesContainer GetPaged(int currentPage, int recordsPerPage)
        {

            var pageNumber = currentPage;
            var pageSize = recordsPerPage;
            var begin = (pageNumber - 1) * pageSize;

            int totalNumberOfRecords = _entidadesApp.TotalRecords();
            //var totalNumberOfRecords = 15782;
            //var students = db.Students.OrderBy(r => r.ID).Skip(begin).Take(pageSize).ToList();

            //var studentsContainer = new StudentsContainer { Students = students, RecordCount = totalNumberOfRecords };

            var entidadesContainer = new EntidadesContainer { EntidadesList = _entidadesApp.GetPaged(begin, pageSize), RecordCount = totalNumberOfRecords };

            return entidadesContainer;

            //return Request.CreateResponse(HttpStatusCode.Created, _entidadesApp.GetPaged(begin, pageSize));
        }

        public class EntidadesContainer
        {
            public IEnumerable<EntidadesViewModel> EntidadesList { get; set; }
            public int RecordCount { get; set; }
        }

        [HttpGet]
        [Route("entidades/{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            var entidade = _entidadesApp.GetById(id);

            if (entidade == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro não encontrado");
            }

            return Request.CreateResponse(HttpStatusCode.Created, entidade);

        }

        [HttpPost]
        [Route("entidades")]
        public HttpResponseMessage Post(EntidadesViewModel entidade)
        {
            if(ModelState.IsValid)
            {
                _entidadesApp.Add(entidade);
                return Request.CreateResponse(HttpStatusCode.Created, entidade);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("entidades")]
        public HttpResponseMessage Put(EntidadesViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                _entidadesApp.Add(entidade);
                return Request.CreateResponse(HttpStatusCode.Created, entidade);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        [Route("entidades/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            _entidadesApp.Remove(id);
            return Request.CreateResponse(HttpStatusCode.Created, "Dados Excluídos");            
        }
    }
}
