using System.Data.Entity;
using CT.Infra.Data.Interfaces;

namespace CT.Infra.Data.Context
{
    public class BaseContext : DbContext, IDbContext
    {
        public BaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}