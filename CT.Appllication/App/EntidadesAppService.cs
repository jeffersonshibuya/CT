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
    public class EntidadesAppService : AppServiceBase<BarraFisikContext>, IEntidadesAppService
    {
        private readonly IEntidadesService _entidadesService;

        public EntidadesAppService(IEntidadesService entidadesService)
        {
            _entidadesService = entidadesService;
        }

        public IEnumerable<EntidadesViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Entidades>, IEnumerable<EntidadesViewModel>>(_entidadesService.GetAll());
        }

        public IEnumerable<EntidadesViewModel> GetPaged(int begin, int pageSize)
        {
            return Mapper.Map<IEnumerable<Entidades>, IEnumerable<EntidadesViewModel>>(_entidadesService.GetPaged(begin, pageSize));
        }

        public Int32 TotalRecords()
        {
            return _entidadesService.TotalRecords();
        }

        public void Add(EntidadesViewModel entidadeViewModel)
        {
            var entidade = Mapper.Map<EntidadesViewModel, Entidades>(entidadeViewModel);

            BeginTransaction();
            _entidadesService.Add(entidade);
            Commit();
        }
       
        public EntidadesViewModel GetById(int id)
        {
            return Mapper.Map<Entidades, EntidadesViewModel>(_entidadesService.GetById(id));
        }

        public void Update(EntidadesViewModel entidadeViewModel)
        {
            var entidade = Mapper.Map<EntidadesViewModel, Entidades>(entidadeViewModel);

            BeginTransaction();
            _entidadesService.Add(entidade);
            Commit();
        }

        public void Remove(int id)
        {
            var entidade = Mapper.Map<EntidadesViewModel, Entidades>(GetById(id));

            BeginTransaction();
            _entidadesService.Remove(entidade);
            Commit();
        }

        public void Dispose()
        {
            _entidadesService.Dispose();
        }

    }
}
