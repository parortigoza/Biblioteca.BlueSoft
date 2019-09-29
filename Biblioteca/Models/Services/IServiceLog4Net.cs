using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Services
{
    public interface IServiceLog4Net
    {
        void EscribeLog4Net(string error);
    }
}
