using System;
using System.Collections.Generic;
using MenuPlanner.Core;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Console.DataTransferObject
{
    public class DetailsDto
    {
        public DateTime Date { get; set; }

        public StringKeyToObjectMap<DishesDto> Dishes { get; set; }

        public List<PhotoDto> Photos { get; set; }

        public List<int> Tags { get; set; }
    }
}