using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Services;

namespace LearnAngular.Services
{
    public class UsuarioService : DataServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUnitOfWorkService _uow;

        public UsuarioService(UnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
        }
    }
}
