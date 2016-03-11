using System.Collections.Generic;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Domain.Interfaces.Services;

namespace CT.Domain.Services
{
    public class TesteService : ITesteService
    {
        private readonly ITesteRepository _testeRepository;

        public TesteService(ITesteRepository testeRepository)
        {
            _testeRepository = testeRepository;
        }


        public IEnumerable<string> GetTeste()
        {
            return _testeRepository.GetTeste();
        }
    }
}