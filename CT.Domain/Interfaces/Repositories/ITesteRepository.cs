using System.Collections.Generic;
using CT.Domain.Entities;

namespace CT.Domain.Interfaces.Repositories
{
    public interface ITesteRepository : IRepositoryBase<Entidades>
    {
        IEnumerable<string> GetTeste();
    }
}