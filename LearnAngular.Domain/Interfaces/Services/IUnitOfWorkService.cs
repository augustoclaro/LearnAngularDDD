using System;

namespace LearnAngular.Domain.Interfaces.Services
{
    public interface IUnitOfWorkService : IDisposable
    {
        void Commit();
        void RollBack();
        T Service<T>() where T : class;
        T Repository<T>() where T : class;
    }
}
