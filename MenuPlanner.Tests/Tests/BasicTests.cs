using System.IO;
using MenuPlanner.Console.DataTransferObject;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace MenuPlanner.Tests.Tests
{
    public class BasicTests : TestSuitBase
    {
        public BasicTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Theory(DisplayName = "read a random user file and deserialize")]
        [InlineData(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data\2627.json")]
        [InlineData(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data\10780.json")]
        public void Read_And_Deserialize(string filePath)
        {
            var content = File.ReadAllText(filePath);

            var root = JsonConvert.DeserializeObject<RootDto>(content);

            Start_Verifying()
                .Verify_Defined(root);
        }

        [Fact(DisplayName = "read all files then deserialize then combine one by one")]
        public void Read_All_And_Deserialize()
        {
            var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
                .GetFiles();

            foreach (var file in dataFiles)
            {
                var content = File.ReadAllText(file.FullName);

                var root = JsonConvert.DeserializeObject<RootDto>(content);

                Start_Verifying()
                    .Verify_Defined(root, false);

                OutputHelper.XUnitOutputHelper.WriteLine($"Success for file: [{file.Name}]");
            }
        }
    }
}
