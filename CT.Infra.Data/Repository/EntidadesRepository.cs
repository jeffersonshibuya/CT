using System;
using System.Collections.Generic;
using System.Linq;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Infra.Data.Context;

namespace CT.Infra.Data.Repository
{
    public class EntidadesRepository : RepositoryBase<Entidades, BarraFisikContext>, IEntidadesRepository
    {
        public override IEnumerable<Entidades> GetAll()
        {
            return DbSet.Take(10).ToList();
        }

        public IEnumerable<Entidades>  GetPaged(int begin, int pageSize)
        {
            return DbSet.OrderBy(c => c.ENT_COD).Skip(begin).Take(pageSize).ToList();
        }

        public Int32 TotalRecords()
        {
            return DbSet.Count();
        }
    }
}