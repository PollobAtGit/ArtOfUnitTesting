namespace MenuPlanner.Core.Domain
{
    public class Calender
    {
        public int UserId { get; set; }

        public DateTimeToObjectMap<int> DateToDayId { get; set; }

        public IntKeyToObjectMap<int> DishIdToMealId { get; set; }

        public IntKeyToObjectMap<int> MealIdToDayId { get; set; }

        public IntKeyToObjectMap<DaysWithDetails> DaysWithDetails { get; set; }

        public Calender(int userId)
        {
            UserId = userId;
        }
    }
}