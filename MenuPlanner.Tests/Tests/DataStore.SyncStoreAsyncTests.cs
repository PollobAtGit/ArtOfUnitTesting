using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MenuPlanner.Console;
using MenuPlanner.Core.Service;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using Mapper = MenuPlanner.Console.Mapper;

namespace MenuPlanner.Tests.Tests
{
    public class DataStoreTests
    {
        public class SyncStoreAsyncTests : TestSuitBase
        {
            public SyncStoreAsyncTests(ITestOutputHelper outputHelper) : base(outputHelper)
            {
            }

            [Fact(DisplayName = "should sync data store from json files")]
            public async Task Should_Insert_Input_File_Data()
            {
                // Arrange

                var deserializer = new Deserializer(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data\2627.json", Mapper.GetMapper());

                var dataStore = new DataStore();

                // Act

                await dataStore.SyncAsync(deserializer.DeserializeContent());

                // Assert

                var calenders = dataStore.GetCalenders();

                Start_Verifying()
                    .Verify_Defined(calenders, false)
                    .Verify(() => calenders.ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.DishIdToMealId).ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.DateToDayId).ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.MealIdToDayId).ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.DaysWithDetails).ShouldNotBeNull().ShouldNotBeEmpty());
            }

            [Fact(DisplayName = "should sync data store from all json files")]
            public async Task Should_Insert_Input_File_Data_From_Given_Directory()
            {

                // Arrange

                var dataStore = new DataStore();

                var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
                    .GetFiles();

                // Act

                foreach (var file in dataFiles)
                {
                    var deserializer = new Deserializer(file.FullName, Mapper.GetMapper());

                    await dataStore.SyncAsync(deserializer.DeserializeContent());
                }

                // Assert

                var calenders = dataStore.GetCalenders();

                Start_Verifying()
                    .Verify_Defined(calenders, false)
                    .Verify(() => calenders.ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Count.ShouldBeGreaterThan(1))
                    .Verify(() => calenders.Select(x => x.DishIdToMealId).ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.DateToDayId).ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.MealIdToDayId).ShouldNotBeNull().ShouldNotBeEmpty())
                    .Verify(() => calenders.Select(x => x.DaysWithDetails).ShouldNotBeNull().ShouldNotBeEmpty());
            }

           
        }
    }
}