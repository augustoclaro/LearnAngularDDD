using System;
using System.Linq;
using LearnAngular.Domain.Entities;
using LearnAngular.Domain.Interfaces.Applications;
using LearnAngular.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace LearnAngular.Application
{
    public class CategoriaAppService : AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IUnitOfWorkService _uow;

        public CategoriaAppService(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _categoriaService = uow.Service<ICategoriaService>();
        }

        public List<Categoria> ObterTodas()
        {
            return _categoriaService.ObterTodas();
        }


        public void Criar(Categoria categoria)
        {
            Add(categoria);
            _uow.Commit();
        }


        public void Alterar(Categoria categoria)
        {
            Update(categoria);
            _uow.Commit();
        }

        public void Excluir(Guid IdCategoria)
        {
            Remove(Get(el => el.IdCategoria == IdCategoria));
            _uow.Commit();
        }
    }
}
