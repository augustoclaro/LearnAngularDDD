using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LearnAngular.Data.Context;
using LearnAngular.Domain.Interfaces.Repositories;

namespace LearnAngular.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AngularContext Db;

        public RepositoryBase(AngularContext context)
        {
            Db = context;
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return Db.Set<TEntity>().Where(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return Db.Set<TEntity>().FirstOrDefault(expr);
        }
    }
}
