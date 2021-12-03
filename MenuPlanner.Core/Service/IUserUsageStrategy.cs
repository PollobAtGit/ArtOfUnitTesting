using System;
using System.Collections.Generic;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public interface IUserUsageStrategy
    {
        List<UserIdByCount> GetUserIds(DateTime fromDate, DateTime toDate);
    }
}