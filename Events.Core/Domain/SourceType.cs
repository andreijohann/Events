using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Core.Domain
{
    public enum SourceType : byte
    {
        Cpf = 1,
        Ie = 2,
        Cnpj8 = 3,
        Cnpj14 = 4
    }
}
