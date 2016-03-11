using System.Collections.Generic;
using CT.Domain.Entities;

namespace CT.Domain.Interfaces.Services
{
    public interface ITesteService
    {
        IEnumerable<string> GetTeste();
    }
}