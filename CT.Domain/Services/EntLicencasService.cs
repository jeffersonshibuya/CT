using System;
using System.Collections.Generic;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Domain.Interfaces.Services;

namespace CT.Domain.Services
{
    public class EntLicencasService : ServiceBase<EntLicencas>, IEntLicencasService
    {
        private readonly IEntLicencasRepository _entLicencasRepository;

        public EntLicencasService(IEntLicencasRepository entLicencasRepository) :base(entLicencasRepository)
        {
            _entLicencasRepository = entLicencasRepository;
        }

        //public IEnumerable<EntProjetos> GetByEntidade(int idEntidade)
        //{
        //    return _entPorjetosRepository.GetByEntidade(idEntidade);
        //}
    }
}