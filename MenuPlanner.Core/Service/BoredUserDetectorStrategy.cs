using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public class BoredUserDetectorStrategy : IUserUsageStrategy
    {
        private readonly ActiveUserDetectorStrategy _activeUserDetectorStrategy;
        private readonly SuperActiveUserDetectorStrategy _superActiveUserDetectorStrategy;

        public BoredUserDetectorStrategy(ActiveUserDetectorStrategy activeUserDetectorStrategy, SuperActiveUserDetectorStrategy superActiveUserDetectorStrategy)
        {
            _activeUserDetectorStrategy = activeUserDetectorStrategy;
            _superActiveUserDetectorStrategy = superActiveUserDetectorStrategy;
        }

        public List<UserIdByCount> GetUserIds(DateTime fromDate, DateTime toDate)
        {
            var previouslyActiveUsers = _activeUserDetectorStrategy
                .GetUserIds(DateTime.MinValue, fromDate.AddDays(-1))
                .Select(x => x.UserId.Id)
                .ToImmutableHashSet();

            var users = _activeUserDetectorStrategy
                .GetStatistics()
                .Select(x => x.UserId.Id)
                .ToImmutableHashSet();

            var currentlyEngagedUserIds = _activeUserDetectorStrategy.GetUserIds(fromDate, toDate)
                .Concat(_superActiveUserDetectorStrategy.GetUserIds(fromDate, toDate))
                .Select(x => x.UserId.Id)
                .ToImmutableHashSet();

            var currentlyNotEngagedUserIds = users.Except(currentlyEngagedUserIds);

            return previouslyActiveUsers
                .Intersect(currentlyNotEngagedUserIds)
                .Select(x => new UserIdByCount(new UserId(x), int.MinValue))
                .ToList();
        }
    }
}