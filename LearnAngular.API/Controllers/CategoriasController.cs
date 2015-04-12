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
    [RoutePrefix("api/categorias")]
    public class CategoriasController : ApiController
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [Authorize(Roles = "User")]
        public List<Categoria> GetCategorias()
        {
            return _categoriaAppService.ObterTodas();
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Criar(Categoria categoria)
        {
            try
            {
                categoria.IdCategoria = Guid.NewGuid();
                categoria.DataInclusao = DateTime.Now;
                _categoriaAppService.Criar(categoria);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [HttpPatch]
        [Authorize(Roles = "User")]
        public HttpResponseMessage Alterar(Categoria categoria)
        {
            try
            {
                //using (var myRepo = new Repository())
                //{
                //    categoria = myRepo.Get<Categoria>(el => el.IdCategoria == categoria.IdCategoria)
                //        .Populating(new
                //        {
                //            categoria.NomeCategoria
                //        });
                //    myRepo.Update(categoria);
                //    myRepo.Commit();
                //}
                _categoriaAppService.Alterar(categoria);
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
                _categoriaAppService.Excluir(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
