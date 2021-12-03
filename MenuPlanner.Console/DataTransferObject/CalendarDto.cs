using MenuPlanner.Core;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Console.DataTransferObject
{
    public class CalendarDto
    {
        public StringKeyToObjectMap<int> DateToDayId { get; set; }

        public StringKeyToObjectMap<int> DishIdToMealId { get; set; }

        public StringKeyToObjectMap<int> MealIdToDayId { get; set; }

        public StringKeyToObjectMap<DaysWithDetailsDto> DaysWithDetails { get; set; }
    }
}