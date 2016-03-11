using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using CT.Domain.Interfaces.Repositories;
using CT.Infra.Data.Context;
using CT.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System.Linq.Expressions;

namespace CT.Infra.Data.Repository
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> 
        where TEntity : class 
        where TContext: IDbContext, new()
    {
        private readonly ContextManager<TContext> _contextManager = ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;
        protected IDbSet<TEntity> DbSet;
        protected readonly IDbContext Context;

        public RepositoryBase()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public void Add(TEntity obj)
        {
            DbSet.AddOrUpdate(obj);
        }

        public TEntity GetById(int id)
        {
            var entry = DbSet.Find(id);
            if (entry != null)
                Context.Entry(entry).State = EntityState.Detached;
            return entry;
        }

        public void Update(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Remove(TEntity obj)
        {
            var entry = Context.Entry(obj);
            if (entry.State == EntityState.Detached)
                DbSet.Attach(obj);
            DbSet.Remove(obj);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}