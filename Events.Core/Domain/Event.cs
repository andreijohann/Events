using Events.Core.Domain;
using System;
using System.Collections.Generic;

namespace Events.Core.Domain
{
    public class Event
    {

        public Event()
        {
            Tags = new HashSet<Tag>();
        }

        public long Id { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public DateTime? DthEvent { get; set; }
        public DateTime? DthCreated { get; set; }
        public Source Source { get; set; }
        public long SourceId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        //TODO: Create property EventType ??? / Severity / Importance (Information, Warning, etc..)
    }
}
