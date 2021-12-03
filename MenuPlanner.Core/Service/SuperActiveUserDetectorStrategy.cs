using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public class SuperActiveUserDetectorStrategy : UserUsageDetectorBase
    {
        public SuperActiveUserDetectorStrategy(Filterer filterer, DataStore dataStore) : base(filterer, dataStore)
        {
        }

        protected override List<UserIdByCount> FilterCondition(List<MealId> meals)
        {
            return meals
                .GroupBy(x => x.UserId.Id)
                .Select(x => new UserIdByCount(new UserId(x.Key), x.Count()))
                .Where(x => x.Total > 10)
                .ToList();
        }
    }
}