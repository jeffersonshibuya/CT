using System.Collections.Generic;
using System.Linq;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Infra.Data.Context;

namespace CT.Infra.Data.Repository
{
    public class EntLicencasRepository : RepositoryBase<EntLicencas, BarraFisikContext>, IEntLicencasRepository
    {
        //public IEnumerable<EntProjetos> GetByEntidade(int idEntidade)
        //{
        //    return DbSet.Where(c => c.ENT_COD == idEntidade).ToList();
        //} 
    }
}