using System;
using System.Collections.Generic;

namespace MenuPlanner.Console.DataTransferObject
{
    public class DayDto
    {
        public DateTime Date { get; set; }

        public List<object> DeletedDefaultMealTypes { get; set; }

        public int Id { get; set; }

        public int UserId { get; set; }
    }
}