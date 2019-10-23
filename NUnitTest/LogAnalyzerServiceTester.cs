using NUnit.Framework;
using NUnitTest.Fakes;
using Service.Implementation;

namespace NUnitTest
{
    [TestFixture]
    public class LogAnalyzerServiceTester
    {
        [TestCase("a.slf"), TestCase("b.lf"), TestCase("r.slf")]
        public void Should_Validate_Properly_If_Configuration_IsMissing(string file)
        {
            var analyzer = new LogFileAnalyzer(new FakeNoConfigurationExistsFileReader());

            analyzer.ValidateFile(file);

            Assert.IsFalse(analyzer.WasLastFileValid);
        }

        [TestCase(true, "a.slf"), TestCase(false, "b.lf"), TestCase(true, "r.slf")]
        public void Should_ValidateFileName(bool expected, string file)
        {
            var analyzer = new LogFileAnalyzer(new FakeNoConfigurationExistsFileReader());

            analyzer.ValidateFile(file);

            Assert.AreEqual(expected, analyzer.WasLastFileValid);
        }
    }
}
