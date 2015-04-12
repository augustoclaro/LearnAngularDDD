using System.Linq;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace LearnAngular.Services
{
    public class CategoriaService : DataServiceBase<Categoria>, ICategoriaService
    {
        private readonly IUnitOfWorkService _uow;

        public CategoriaService(UnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
        }

        public List<Categoria> ObterTodas()
        {
            return GetAll().ToList();
        }
    }
}
