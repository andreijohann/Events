using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime? DthCreated { get; set; }
    }
}
