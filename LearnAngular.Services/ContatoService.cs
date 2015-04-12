using System;
using System.Linq;
using System.Collections.Generic;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Services;

namespace LearnAngular.Services
{
    public class ContatoService : DataServiceBase<Contato>, IContatoService
    {
        private readonly IUnitOfWorkService _uow;

        public ContatoService(UnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
        }

        public List<Contato> ObterTodos()
        {
            return GetAll().ToList();
        }
    }
}
