namespace MenuPlanner.Core.Domain
{
    public class MealId
    {
        public int Id { get; }
        
        public UserId UserId { get; }

        public MealId(int mealId, UserId userId)
        {
            Id = mealId;
            UserId = userId;
        }
    }
}