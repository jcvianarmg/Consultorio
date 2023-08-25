using Consult.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consult.Manager.Interfaces.Services
{
    public interface IJwtService
    {        string GerarToken(Usuario usuario);
    }
}
