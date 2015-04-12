using LearnAngular.Data.Context;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Repositories;

namespace LearnAngular.Data.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(AngularContext Db)
            : base(Db)
        {
        }
    }
}
