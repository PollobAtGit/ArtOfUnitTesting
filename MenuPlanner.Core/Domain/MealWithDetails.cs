namespace MenuPlanner.Core.Domain
{
    public class MealWithDetails
    {
        public StringKeyToObjectMap<MealDetails> MealsWithDetails { get; set; }
    }
}