using MenuPlanner.Core.Domain;

namespace MenuPlanner.Console.DataTransferObject
{
    public class MealsWithDetailsDto
    {
        public StringKeyToObjectMap<MealDetailsDto> MealsWithDetails { get; set; }
    }

    public class MealDetailsDto
    {
        public MealDto Meal { get; set; }

        public DetailsDto Details { get; set; }
    }
}