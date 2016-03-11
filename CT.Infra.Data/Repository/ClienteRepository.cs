using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Infra.Data.Context;

namespace CT.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente, BarraFisikContext>, IClienteRepository
    {
    }
}