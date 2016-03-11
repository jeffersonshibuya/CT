using System;
using System.Collections.Generic;
using CT.Domain.Entities;

namespace CT.Domain.Interfaces.Repositories
{
    public interface IEntidadesRepository : IRepositoryBase<Entidades>
    {
        IEnumerable<Entidades> GetPaged(int begin, int pageSize);
        Int32 TotalRecords();
    }
}