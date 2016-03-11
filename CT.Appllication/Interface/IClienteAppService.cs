using System.Collections.Generic;
using CT.Appllication.ViewModels;

namespace CT.Appllication.Interface
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteViewModel> GetAll();
        void Add(ClienteViewModel cliente);
        ClienteViewModel GetById(int id);
        void Update(ClienteViewModel cliente);
        void Remove(int id);
    }
}