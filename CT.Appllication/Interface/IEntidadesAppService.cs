using System;
using System.Collections.Generic;
using CT.Appllication.ViewModels;

namespace CT.Appllication.Interface
{
    public interface IEntidadesAppService
    {
        IEnumerable<EntidadesViewModel> GetAll();
        IEnumerable<EntidadesViewModel> GetPaged(int begin, int pageSize);
        Int32 TotalRecords();
        void Add(EntidadesViewModel entidade);
        EntidadesViewModel GetById(int id);
        void Update(EntidadesViewModel entidade);
        void Remove(int id);
    }
}