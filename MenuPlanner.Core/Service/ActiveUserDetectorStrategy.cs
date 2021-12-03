using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public class ActiveUserDetectorStrategy : UserUsageDetectorBase
    {
        public ActiveUserDetectorStrategy(Filterer filterer, DataStore dataStore) : base(filterer, dataStore)
        {
        }

        protected override List<UserIdByCount> FilterCondition(List<MealId> meals)
        {
            return meals
                .GroupBy(x => x.UserId.Id)
                .Select(x => new UserIdByCount(new UserId(x.Key), x.Count()))
                .Where(x => x.Total >= 5 && x.Total < 11)
                .ToList();
        }
    }
}