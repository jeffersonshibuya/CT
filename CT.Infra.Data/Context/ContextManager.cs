using System.Web;
using CT.Infra.Data.Interfaces;

namespace CT.Infra.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        //OneContextPerRequest
        private const string ContextKey = "ContextManager.Context";

        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
                HttpContext.Current.Items[ContextKey] = new TContext();

            return (IDbContext)HttpContext.Current.Items[ContextKey];
        }
    }
}