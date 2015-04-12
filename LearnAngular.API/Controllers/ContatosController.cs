using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Applications;

namespace LearnAngular.API.Controllers
{
    [RoutePrefix("api/contatos")]
    public class ContatosController : ApiController
    {
        private readonly IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        [Authorize(Roles = "User")]
        public List<Contato> GetContatos()
        {
            return _contatoAppService.ObterTodos();
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Criar(Contato contato)
        {
            try
            {
                contato.IdContato = Guid.NewGuid();
                contato.DataInclusao = DateTime.Now;
                _contatoAppService.Criar(contato);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [HttpPatch]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Alterar(Contato contato)
        {
            try
            {
                _contatoAppService.Alterar(contato);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [HttpDelete]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Excluir(Guid id)
        {
            try
            {
                _contatoAppService.Excluir(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
