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
    public class EntProjetosAppService : AppServiceBase<BarraFisikContext>, IEntProjetosAppService
    {
        private readonly IEntProjetosService _entProjetosService;

        public EntProjetosAppService(IEntProjetosService entProjetosService)
        {
            _entProjetosService = entProjetosService;
        }

        public void Add(EntProjetosViewModel entProjetosViewModel)
        {
            var entidade = Mapper.Map<EntProjetosViewModel, EntProjetos>(entProjetosViewModel);

            BeginTransaction();
            _entProjetosService.Add(entidade);
            Commit();
        }

        public EntProjetosViewModel GetById(int id)
        {
            return Mapper.Map<EntProjetos, EntProjetosViewModel>(_entProjetosService.GetById(id));
        }

        public IEnumerable<EntProjetosViewModel> GetByEntidade(int idEntidade)
        {
            return Mapper.Map<IEnumerable<EntProjetos>, IEnumerable<EntProjetosViewModel>>(_entProjetosService.GetByEntidade(idEntidade));
        }

        public IEnumerable<EntProjetosViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<EntProjetos>, IEnumerable<EntProjetosViewModel>>(_entProjetosService.GetAll());
        }

        public void Update(EntProjetosViewModel entidadeViewModel)
        {
            var entidade = Mapper.Map<EntProjetosViewModel, EntProjetos>(entidadeViewModel);

            BeginTransaction();
            _entProjetosService.Add(entidade);
            Commit();
        }

        public void Remove(int id)
        {
            var entidade = Mapper.Map<EntProjetosViewModel, EntProjetos>(GetById(id));

            BeginTransaction();
            _entProjetosService.Remove(entidade);
            Commit();
        }


        public void Dispose()
        {
            _entProjetosService.Dispose();
        }
    }
}
