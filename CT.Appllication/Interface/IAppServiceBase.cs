using CT.Infra.Data.Interfaces;

namespace CT.Appllication.Interface
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}