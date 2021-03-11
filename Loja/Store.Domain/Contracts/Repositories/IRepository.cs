using Store.Domain.Enitities;
using System;
using System.Collections.Generic;

namespace Store.Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);

        IEnumerable<T> Get();
        T Get(int id);
    }
}
