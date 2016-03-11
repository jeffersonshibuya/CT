using System;
using System.Collections.Generic;
using CT.Appllication.ViewModels;

namespace CT.Appllication.Interface
{
    public interface IEntProjetosAppService : IDisposable
    {
        IEnumerable<EntProjetosViewModel> GetByEntidade(int idEntidade);       
        IEnumerable<EntProjetosViewModel> GetAll();       
        void Add(EntProjetosViewModel projeto);
        EntProjetosViewModel GetById(int id);
        void Update(EntProjetosViewModel projeto);
        void Remove(int id);
    }
}