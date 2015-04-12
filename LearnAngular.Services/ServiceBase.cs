using LearnAngular.Domain.Interfaces.Services;

namespace LearnAngular.Services
{
    public class ServiceBase : IServiceBase
    {
        private IUnitOfWorkService _uow;
        public ServiceBase(IUnitOfWorkService uow)
        {
            _uow = uow;
        }
    }
}
