using System;
using System.Collections.Generic;

namespace LearnAngular.Domain.Interfaces.Applications
{
    public interface IAppDataServiceBase<TEntity> : IAppServiceBase where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> Find(Func<TEntity, bool> expr);
        TEntity Get(Func<TEntity, bool> expr);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
