using System;
using System.IO;
using System.Threading.Tasks;
using MenuPlanner.Console;
using MenuPlanner.Core;
using MenuPlanner.Core.Service;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using Mapper = MenuPlanner.Console.Mapper;

namespace MenuPlanner.Tests.Tests
{
    public class ActiveUserUsageDetectorTests
    {
        public class GetUserIdsTests : TestSuitBase
        {
            public GetUserIdsTests(ITestOutputHelper outputHelper) : base(outputHelper)
            {
            }

            [Theory(DisplayName = "Get active users (meal count >= 5 and < 11)")]
            [InlineData("2000-10-30", "2030-11-05")]
            public async Task Get_Active_Users(string fromDate, string toDate)
            {
                // Arrange

                var dataStore = new DataStore();


                var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
                    .GetFiles();

                foreach (var file in dataFiles)
                {
                    await dataStore.SyncAsync(new Deserializer(file.FullName, Mapper.GetMapper()).DeserializeContent());
                }

                var usageDetector = new ActiveUserDetectorStrategy(new Filterer(dataStore), dataStore);

                // Act

                var userIds = usageDetector
                    .GetUserIds(DateTime.Parse(fromDate), DateTime.Parse(toDate));

                // Assert

                Start_Verifying()
                    .Verify_Defined(userIds)
                    .Verify(() => userIds.Count.ShouldBe(1));

                OutputHelper.XUnitOutputHelper.WriteLine(userIds.Count.ToString());
            }

            [Theory(DisplayName = "get overall usage statistics")]
            [InlineData("2000-10-30", "2030-11-05")]
            public async Task Get_Statistics(string fromDate, string toDate)
            {
                // Arrange

                var dataStore = new DataStore();


                var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
                    .GetFiles();

                foreach (var file in dataFiles)
                {
                    await dataStore.SyncAsync(new Deserializer(file.FullName, Mapper.GetMapper()).DeserializeContent());
                }

                var usageDetector = new ActiveUserDetectorStrategy(new Filterer(dataStore), dataStore);

                // Act

                var userIds = usageDetector.GetStatistics();

                // Assert

                Start_Verifying()
                    .Verify_Defined(userIds)
                    .Verify(() => userIds.Count.ShouldBe(20));

                OutputHelper.XUnitOutputHelper.WriteLine(userIds.Count.ToString());
            }

            [Theory(DisplayName = "Get super active users (meal count > 10)")]
            [InlineData("2000-10-30", "2030-11-05")]
            public async Task Get_Super_Active_Users(string fromDate, string toDate)
            {
                // Arrange

                var dataStore = new DataStore();


                var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
                    .GetFiles();

                foreach (var file in dataFiles)
                {
                    await dataStore.SyncAsync(new Deserializer(file.FullName, Mapper.GetMapper()).DeserializeContent());
                }

                var usageDetector = new SuperActiveUserDetectorStrategy(new Filterer(dataStore), dataStore);

                // Act

                var userIds = usageDetector
                    .GetUserIds(DateTime.Parse(fromDate), DateTime.Parse(toDate));

                // Assert

                Start_Verifying()
                    .Verify_Defined(userIds)
                    .Verify(() => userIds.Count.ShouldBe(18));

                OutputHelper.XUnitOutputHelper.WriteLine(userIds.Count.ToString());
            }

            [Theory(DisplayName = "Get bored users (active previously but not active now)")]
            [InlineData("2000-10-30", "2030-11-05")]
            public async Task Get_Bored_Users(string fromDate, string toDate)
            {
                // Arrange

                var dataStore = new DataStore();

                var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
                    .GetFiles();

                foreach (var file in dataFiles)
                {
                    await dataStore.SyncAsync(new Deserializer(file.FullName, Mapper.GetMapper()).DeserializeContent());
                }

                var filterer = new Filterer(dataStore);

                var usageDetector = new BoredUserDetectorStrategy(new ActiveUserDetectorStrategy(filterer, dataStore), new SuperActiveUserDetectorStrategy(filterer, dataStore));

                // Act

                var userIds = usageDetector
                    .GetUserIds(DateTime.Parse(fromDate), DateTime.Parse(toDate));

                // Assert

                Start_Verifying()
                    .Verify_Defined(userIds)
                    .Verify(() => userIds.Count.ShouldBe(1));

                OutputHelper.XUnitOutputHelper.WriteLine(userIds.Count.ToString());
            }
        }
    }
}