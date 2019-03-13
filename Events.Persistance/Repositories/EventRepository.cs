using Events.Core;
using Events.Core.Domain;
using Events.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Persistence.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(EventsContext context)
            : base(context)
        {
            
        }

        public IEnumerable<Event> GetEventsWithCategoriesAndTags(int PageIndex, int pageSize)
        {
            return EventsContext.Events
                .Include(c => c.Category)
                .Include(c => c.Tags)
                .Skip((PageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private EventsContext EventsContext { get { return _context as EventsContext; } }
    }
}
