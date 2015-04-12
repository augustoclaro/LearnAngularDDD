using LearnAngular.Domain.Entities;
using System.Collections.Generic;

namespace LearnAngular.Domain.Interfaces.Services
{
    public interface ICategoriaService : IDataServiceBase<Categoria>
    {
        List<Categoria> ObterTodas();
    }
}
