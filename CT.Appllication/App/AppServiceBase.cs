using CT.Appllication.Interface;
using CT.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace CT.Appllication.App
{
    public class AppServiceBase<TContext> : IAppServiceBase<TContext> where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }

        public virtual void Fechar()
        {
            _uow.Dispose();
        }
    }
}