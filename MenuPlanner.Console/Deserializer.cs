using System.IO;
using System.Linq;
using AutoMapper;
using MenuPlanner.Console.DataTransferObject;
using MenuPlanner.Core.Domain;
using Newtonsoft.Json;

namespace MenuPlanner.Console
{
    public class Deserializer
    {
        private readonly string _file;
        private readonly IMapper _mapper;

        public Deserializer(string file, IMapper mapper)
        {
            _file = file;
            _mapper = mapper;
        }

        public Calender DeserializeContent()
        {
            var root = JsonConvert.DeserializeObject<RootDto>(File.ReadAllText(_file));

            var dishIdToMealId = _mapper.Map<StringKeyToObjectMap<int>, IntKeyToObjectMap<int>>(root.Calendar.DishIdToMealId);
            var dateToDayId = _mapper.Map<StringKeyToObjectMap<int>, DateTimeToObjectMap<int>>(root.Calendar.DateToDayId);
            var mealToDayId = _mapper.Map<StringKeyToObjectMap<int>, IntKeyToObjectMap<int>>(root.Calendar.MealIdToDayId);
            var details = _mapper.Map<StringKeyToObjectMap<DaysWithDetailsDto>, IntKeyToObjectMap<DaysWithDetails>>(root.Calendar.DaysWithDetails);

            var userId = root.Calendar.DaysWithDetails.Values
                .Select(x => x.Day.UserId)
                .Distinct()
                .Single();

            return new Calender(userId)
            {
                DishIdToMealId = dishIdToMealId,
                DateToDayId = dateToDayId,
                MealIdToDayId = mealToDayId,
                DaysWithDetails = details,
            };
        }
    }
}