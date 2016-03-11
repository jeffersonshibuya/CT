using System;
using System.Collections.Generic;
using CT.Domain.Entities;
using CT.Infra.Data.Context;

namespace CT.Appllication.Interface
{
    public interface ITesteAppService
    {
        IEnumerable<string> GetAll();
    }
}