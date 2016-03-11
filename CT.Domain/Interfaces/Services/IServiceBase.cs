using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CT.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity obj);
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Dispose();
    }
}