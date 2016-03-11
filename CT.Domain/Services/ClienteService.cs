using System.Collections.Generic;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Repositories;
using CT.Domain.Interfaces.Services;

namespace CT.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository):base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}