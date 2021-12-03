using System.Collections.Generic;
using System.Threading;

namespace MenuPlanner.Core.Domain
{
    public class Meal
    {
        public int DayId { get; set; }

        public List<object> Goals { get; set; }

        public int Id { get; set; }

        public string Type { get; set; }

        public int UserId { get; set; }

        public bool HasCompleted { get; set; }
    }
}