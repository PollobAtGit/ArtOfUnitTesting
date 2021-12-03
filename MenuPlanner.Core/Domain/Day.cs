using System;
using System.Collections.Generic;

namespace MenuPlanner.Core.Domain
{
    public class Day
    {
        public DateTime Date { get; set; }

        public List<object> DeletedDefaultMealTypes { get; set; }

        public int Id { get; set; }

        public int UserId { get; set; }
    }
}