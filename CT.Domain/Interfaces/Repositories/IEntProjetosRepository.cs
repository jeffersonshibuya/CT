using System;
using System.Collections.Generic;
using CT.Domain.Entities;

namespace CT.Domain.Interfaces.Repositories
{
    public interface IEntProjetosRepository : IRepositoryBase<EntProjetos>
    {
        IEnumerable<EntProjetos> GetByEntidade(int idEntidade);
    }
}