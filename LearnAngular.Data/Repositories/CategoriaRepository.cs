using LearnAngular.Data.Context;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Repositories;

namespace LearnAngular.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AngularContext Db)
            : base(Db)
        {
        }
    }
}
