using AutoMapper;
using MenuPlanner.Console.DataTransferObject;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Console
{
    public static class Mapper
    {
        public static AutoMapper.Mapper GetMapper()
        {
            return new AutoMapper.Mapper(new MapperConfiguration(expression =>
            {
                expression.CreateMap<DaysWithDetailsDto, DaysWithDetails>().ReverseMap();
                expression.CreateMap<DayDto, Day>().ReverseMap();
                expression.CreateMap<MealDetailsDto, MealDetails>().ReverseMap();
                expression.CreateMap<MealsWithDetailsDto, MealWithDetails>().ReverseMap();
                expression.CreateMap<MealDto, Meal>().ReverseMap();
                expression.CreateMap<DetailsDto, Detail>().ReverseMap();
                expression.CreateMap<DishesDto, Dishes>().ReverseMap();
                expression.CreateMap<PhotoDto, Photo>().ReverseMap();
            }));
        }
    }
}
