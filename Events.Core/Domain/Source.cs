using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Core.Domain
{
    public class Source
    {
        public long Id { get; set; }
        public long SourceRegistry { get; set; }
        public string SourceName { get; set; }
        public SourceType? SourceType { get; set; }
        public DateTime? DthCreated { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
