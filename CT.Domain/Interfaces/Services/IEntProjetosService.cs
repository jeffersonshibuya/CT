using System;
using System.Collections.Generic;
using CT.Domain.Entities;

namespace CT.Domain.Interfaces.Services
{
    public interface IEntProjetosService : IServiceBase<EntProjetos>
    {
        IEnumerable<EntProjetos> GetByEntidade(int idEntidade);
    }
}