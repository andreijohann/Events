using Events.Core;
using Events.Core.Repositories;
using Events.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventsContext _context;

        public UnitOfWork(EventsContext context)
        {
            _context = context;
            Events = new EventRepository(_context);

        }

        public IEventRepository Events { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
