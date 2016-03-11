using System;
using System.Collections.Generic;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Domain.Interfaces.Services;

namespace CT.Domain.Services
{
    public class EntidadesService : ServiceBase<Entidades>, IEntidadesService
    {
        private readonly IEntidadesRepository _entidadesRepository;

        public EntidadesService(IEntidadesRepository entidadesRepository):base(entidadesRepository)
        {
            _entidadesRepository = entidadesRepository;
        }

        public IEnumerable<Entidades> GetPaged(int begin, int pageSize)
        {
            return _entidadesRepository.GetPaged(begin, pageSize);
        }

        public Int32 TotalRecords()
        {
            return _entidadesRepository.TotalRecords();
        }
    }
}