using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LearnAngular.Data.Context;
using LearnAngular.Data.Repositories;
using LearnAngular.Domain.Interfaces.Services;

namespace LearnAngular.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private AngularContext Db;
        private Dictionary<Type, object> _services;
        private Dictionary<Type, object> _repositories;

        public UnitOfWorkService()
        {
            Db = new AngularContext();
            _services = new Dictionary<Type, object>();
            _repositories = new Dictionary<Type, object>();
        }

        public void Commit()
        {
            Db.SaveChanges();
        }

        public void RollBack()
        {
            Db.Dispose();
            Db = null;
            Db = new AngularContext();
        }

        public T Service<T>() where T : class
        {
            if (_services.Keys.Contains(typeof(T)))
                return _services[typeof(T)] as T;

            var iType = typeof(T);
            var sType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(el => !el.IsInterface && iType.IsAssignableFrom(el));
            var service = (T)Activator.CreateInstance(sType, this);
            _services.Add(typeof(T), service);
            return service;
        }

        public T Repository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)))
                return _repositories[typeof(T)] as T;

            var iType = typeof(T);
            var sType = typeof(RepositoryBase<>).Assembly.GetTypes().FirstOrDefault(el => !el.IsInterface && iType.IsAssignableFrom(el));
            var repo = (T)Activator.CreateInstance(sType, Db);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Dispose()
        {
            Db.Dispose();
            Db = null;
        }
    }
}
