using System;
using System.Collections.Generic;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Domain.Interfaces.Services;

namespace CT.Domain.Services
{
    public class EntProjetosService : ServiceBase<EntProjetos>, IEntProjetosService
    {
        private readonly IEntProjetosRepository _entProjetosRepository;

        public EntProjetosService(IEntProjetosRepository entProjetosRepository) :base(entProjetosRepository)
        {
            _entProjetosRepository = entProjetosRepository;
        }

        public IEnumerable<EntProjetos> GetByEntidade(int idEntidade)
        {
            return _entProjetosRepository.GetByEntidade(idEntidade);
        }
    }
}