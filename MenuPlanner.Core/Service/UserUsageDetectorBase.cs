using System;
using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public abstract class UserUsageDetectorBase : IUserUsageStrategy
    {
        private readonly Filterer _filterer;
        private readonly DataStore _dataStore;

        protected UserUsageDetectorBase(Filterer filterer, DataStore dataStore)
        {
            _filterer = filterer;
            _dataStore = dataStore;
        }

        private List<MealId> GetFilteredMeals(DateTime fromDate, DateTime toDate)
        {
            var dateIds = _filterer.Filter(fromDate, toDate);

            var distinctIds = dateIds.Select(x => x.Id).ToHashSet();

            var mealIds = new List<MealId>();

            foreach (var calender in _dataStore.GetCalenders())
            {
                mealIds.AddRange(
                    calender
                        .MealIdToDayId
                        .Where(x => distinctIds.Contains(x.Value))
                        .Select(x => new MealId(x.Key, new UserId(calender.UserId)))
                        .ToList()
                );
            }

            return mealIds;
        }

        public List<UserIdByCount> GetStatistics()
        {
            var meals = GetFilteredMeals(DateTime.MinValue, DateTime.MaxValue);

            return meals
                .GroupBy(x => x.UserId.Id)
                .Select(x => new UserIdByCount(new UserId(x.Key), x.Count()))
                .ToList();
        }

        protected abstract List<UserIdByCount> FilterCondition(List<MealId> meals);

        public List<UserIdByCount> GetUserIds(DateTime fromDate, DateTime toDate)
        {
            return FilterCondition(GetFilteredMeals(fromDate, toDate));
        }
    }
}