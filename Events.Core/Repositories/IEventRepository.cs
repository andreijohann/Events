using Events.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Core.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
       IEnumerable<Event> GetEventsWithCategoriesAndTags(int PageIndex, int pageSize);
    }
}
