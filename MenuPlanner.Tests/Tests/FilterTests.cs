using System;
using System.Threading.Tasks;
using MenuPlanner.Console;
using MenuPlanner.Core.Service;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using Mapper = MenuPlanner.Console.Mapper;

namespace MenuPlanner.Tests.Tests
{
    public class FilterTests : TestSuitBase
    {
        public FilterTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Theory(DisplayName = "get date ids from date range")]
        [InlineData("2015-10-30", "2015-11-05")]
        public async Task Get_Date_Ids(string fromStr, string toStr)
        {
            //Arrange 
            
            var deserializer = new Deserializer(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data\2627.json", Mapper.GetMapper());

            var dataStore = new DataStore();
            await dataStore.SyncAsync(deserializer.DeserializeContent());

            var filterer = new Filterer(dataStore);

            // Act 

            var dateIdsWithinRange = filterer
                .Filter(DateTime.Parse(fromStr), DateTime.Parse(toStr));

            // Assert

            Start_Verifying()
                .Verify(() => dateIdsWithinRange.ShouldNotBeEmpty());

            OutputHelper.WriteLine(dateIdsWithinRange);
        }
    }
}