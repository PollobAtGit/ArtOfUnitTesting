using System;
using System.Collections.Generic;

namespace MenuPlanner.Core.Domain
{
    public class Detail
    {
        public DateTime Date { get; set; }

        public StringKeyToObjectMap<Dishes> Dishes { get; set; }

        public List<Photo> Photos { get; set; }

        public List<int> Tags { get; set; }
    }
}