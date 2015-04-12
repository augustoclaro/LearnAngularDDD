using System;
using System.Collections.Generic;
using LearnAngular.Domain.Interfaces.Applications;
using LearnAngular.Domain.Interfaces.Services;

namespace LearnAngular.Application
{
    public class AppServiceBase<TEntity> : IAppServiceBase, IAppDataServiceBase<TEntity> where TEntity : class
    {
        private readonly IDataServiceBase<TEntity> _serviceBase;
        private readonly IUnitOfWorkService _uow;

        public AppServiceBase(IUnitOfWorkService uow)
        {
            _uow = uow;
            _serviceBase = _uow.Service<IDataServiceBase<TEntity>>();
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }


        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _serviceBase.Find(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _serviceBase.Get(expr);
        }
    }
}
