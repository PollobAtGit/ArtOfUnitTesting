using System;
using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public class Filterer
    {
        private readonly DataStore _dataStore;

        public Filterer(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<DateId> Filter(DateTime fromDate, DateTime toDate)
        {
            var calender = _dataStore.GetCalenders();

            var dateIdsWithinRange = calender
                .SelectMany(x => x.DateToDayId)
                .Where(x => x.Key >= fromDate && x.Key <= toDate)
                .Select(x => new DateId(x.Value))
                .ToList();

            return dateIdsWithinRange;
        }
    }
}