namespace MenuPlanner.Core.Domain
{
    public class Dishes
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
    }
}