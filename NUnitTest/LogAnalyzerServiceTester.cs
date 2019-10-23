using NUnit.Framework;
using NUnitTest.Fakes;
using Service.Implementation;

namespace NUnitTest
{
    [TestFixture]
    public class LogAnalyzerServiceTester
    {
        [TestCase("a.slf"), TestCase("b.lf"), TestCase("r.slf")]
        public void Should_Validate_Properly_If_Configuration_File_Contains_Nothing(string file)
        {
            var analyzer = new LogFileAnalyzer(new FakeConfigurationIsEmptyFileReader());

            analyzer.ValidateFile(file);

            Assert.IsFalse(analyzer.WasLastFileValid);
        }

        [TestCase(true, "a.slf"), TestCase(false, "b.lf"), TestCase(true, "r.slf")]
        public void Should_Validate_FileName(bool expected, string file)
        {
            var analyzer = new LogFileAnalyzer(new FakeDefaultConfigurationFileReader());

            analyzer.ValidateFile(file);

            Assert.AreEqual(expected, analyzer.WasLastFileValid);
        }

        [TestCase("a.slf")]
        public void Should_Return_False_If_Configuration_Is_Missing(string file)
        {
            var analyzer = new LogFileAnalyzer(new FakeConfigurationFileIsMissingFileReader());

            analyzer.ValidateFile(file);

            Assert.IsFalse(analyzer.WasLastFileValid);
        }
    }
}
