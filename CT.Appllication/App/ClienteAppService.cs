using System.Collections.Generic;
using AutoMapper;
using CT.Appllication.Interface;
using CT.Appllication.ViewModels;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Services;
using CT.Infra.Data.Context;

namespace CT.Appllication.App
{
    public class ClienteAppService : AppServiceBase<BarraFisikContext>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.GetAll());
        }

        public void Add(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            BeginTransaction();
            _clienteService.Add(cliente);
            Commit();
        }

        public ClienteViewModel GetById(int id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(id));
        }

        public void Remove(int id)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(GetById(id));

            BeginTransaction();
            _clienteService.Remove(cliente);
            Commit();
        }

        public void Update(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            BeginTransaction();
            _clienteService.Update(cliente);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
        }
    }
}