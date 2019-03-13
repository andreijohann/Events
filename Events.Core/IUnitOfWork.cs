using Events.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get;  }
        int Complete();
    }
}
