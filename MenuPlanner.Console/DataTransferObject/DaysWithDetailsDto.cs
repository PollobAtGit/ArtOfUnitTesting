namespace MenuPlanner.Console.DataTransferObject
{
    public class DaysWithDetailsDto
    {
        public DayDto Day { get; set; }

        public MealsWithDetailsDto Details { get; set; }
    }
}