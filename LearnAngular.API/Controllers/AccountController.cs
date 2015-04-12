using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Applications;

namespace LearnAngular.API.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AccountController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public HttpResponseMessage Register(Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.NewGuid();
                usuario.DataInclusao = DateTime.Now;
                try
                {
                    _usuarioAppService.Registrar(usuario);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse<dynamic>(HttpStatusCode.InternalServerError, new { Error = ex.Message });
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

    }
}
