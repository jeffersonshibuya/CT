using System;
using System.Collections.Generic;
using AutoMapper;
using CT.Appllication.Interface;
using CT.Appllication.ViewModels;
using CT.Domain.Entities;
using CT.Domain.Interfaces.Services;
using CT.Infra.Data.Context;

namespace CT.Appllication.App
{
    public class EntLicencasAppService : AppServiceBase<BarraFisikContext>, IEntLicencasAppService
    {
        private readonly IEntLicencasService _entLicencasService;

        public EntLicencasAppService(IEntLicencasService entLicencasService)
        {
            _entLicencasService = entLicencasService;
        }

        public void Add(EntLicencasViewModel entLicencasViewModel)
        {
            var licenca = Mapper.Map<EntLicencasViewModel, EntLicencas>(entLicencasViewModel);

            BeginTransaction();
            _entLicencasService.Add(licenca);
            Commit();
        }

        public EntLicencasViewModel GetById(int id)
        {
            return Mapper.Map<EntLicencas, EntLicencasViewModel>(_entLicencasService.GetById(id));
        }

        //public IEnumerable<EntLicencasViewModel> GetByEntidade(int idEntidade)
        //{
        //    return Mapper.Map<IEnumerable<EntLicencas>, IEnumerable<EntLicencasViewModel>>(_entLicencasService.GetByEntidade(idEntidade));
        //}

        public IEnumerable<EntLicencasViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<EntLicencas>, IEnumerable<EntLicencasViewModel>>(_entLicencasService.GetAll());
        }

        public void Update(EntLicencasViewModel entidadeViewModel)
        {
            var entidade = Mapper.Map<EntLicencasViewModel, EntLicencas>(entidadeViewModel);

            BeginTransaction();
            _entLicencasService.Add(entidade);
            Commit();
        }

        public void Remove(int id)
        {
            var entidade = Mapper.Map<EntLicencasViewModel, EntLicencas>(GetById(id));

            BeginTransaction();
            _entLicencasService.Remove(entidade);
            Commit();
        }


        public void Dispose()
        {
            _entLicencasService.Dispose();
        }
    }
}
