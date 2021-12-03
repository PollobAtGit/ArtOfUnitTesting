using System.Collections.Generic;
using System.Threading.Tasks;
using MenuPlanner.Core.Domain;

namespace MenuPlanner.Core.Service
{
    public class DataStore // singleton
    {
        private readonly List<Calender> _calenders = new List<Calender>();

        public List<Calender> GetCalenders()
        {
            return _calenders;
        }

        public async Task SyncAsync(Calender calender)
        {
            _calenders.Add(calender);

            await Task.CompletedTask;
        }
    }
}