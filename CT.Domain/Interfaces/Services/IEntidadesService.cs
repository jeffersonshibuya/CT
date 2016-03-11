using System;
using System.Collections.Generic;
using CT.Domain.Entities;

namespace CT.Domain.Interfaces.Services
{
    public interface IEntidadesService : IServiceBase<Entidades>
    {
        IEnumerable<Entidades> GetPaged(int begin, int pageSize);
        Int32 TotalRecords();
    }
}