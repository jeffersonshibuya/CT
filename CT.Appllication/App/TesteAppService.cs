using System.Collections.Generic;
using CT.Appllication.Interface;
using CT.Domain.Interfaces.Services;
using CT.Infra.Data.Context;

namespace CT.Appllication.App
{
    public class TesteAppService : AppServiceBase<BarraFisikContext>, ITesteAppService
    {
        private readonly ITesteService _testeService;

        public TesteAppService(ITesteService testeService)
        {
            _testeService = testeService;
        }


        public IEnumerable<string> GetAll()
        {
            return _testeService.GetTeste();
        }

    }
}