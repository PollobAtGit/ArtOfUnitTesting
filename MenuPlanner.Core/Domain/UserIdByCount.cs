namespace MenuPlanner.Core.Domain
{
    public class UserIdByCount
    {
        public int Total { get; }

        public UserId UserId { get; }

        public UserIdByCount(UserId userId, int total)
        {
            UserId = userId;
            Total = total;
        }
    }
}