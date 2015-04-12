using LearnAngular.Data.Context;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Repositories;

namespace LearnAngular.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AngularContext Db)
            : base(Db)
        {
        }
    }
}
