using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Infra.Data.Context;

namespace CT.Infra.Data.Repository
{
    public class TesteRepository : RepositoryBase<Entidades, BarraFisikContext>, ITesteRepository
    {
        public override IEnumerable<Entidades> GetAll()
        {
            return DbSet.Take(10).ToList();
        }

        public IEnumerable<string> GetTeste()
        {
            IList<string> list = new List<string>();

            list.Add("Teste 01");
            list.Add("Teste 02");
            list.Add("Teste 03");

            return list;
        } 
        
         
    }
}