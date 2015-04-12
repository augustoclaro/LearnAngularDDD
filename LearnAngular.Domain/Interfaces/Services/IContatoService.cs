using LearnAngular.Domain.Entities;
using System.Collections.Generic;

namespace LearnAngular.Domain.Interfaces.Services
{
    public interface IContatoService : IDataServiceBase<Contato>
    {
        List<Contato> ObterTodos();
    }
}
