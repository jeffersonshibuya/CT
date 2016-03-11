using System;
using System.Collections.Generic;
using CT.Appllication.ViewModels;

namespace CT.Appllication.Interface
{
    public interface IEntLicencasAppService : IDisposable
    {
        //IEnumerable<EntLicencasViewModel> GetByEntidade(int idEntidade);       
        IEnumerable<EntLicencasViewModel> GetAll();       
        void Add(EntLicencasViewModel projeto);
        EntLicencasViewModel GetById(int id);
        void Update(EntLicencasViewModel projeto);
        void Remove(int id);
    }
}