using System.Collections.Generic;
using CSharpFunctionalExtensions;
using NUnit.Framework;
using NUnitTest.Fakes;

namespace NUnitTest
{
    [TestFixture]
    public class DoubleParserTester
    {
        [Test]
        public void Should_Fail_When_Reader_Is_Not_Configured()
        {
            var doubleParser = new FakeDoubleParser();
            doubleParser.Setup(false);

            var doubleListResult = Result.Failure<List<double>>("initializing");

            Assert.DoesNotThrow(() => doubleListResult = doubleParser.GetDoubles());
            StringAssert.Contains("Object reference not set to an instance of an object", doubleListResult.Error);
        }

        [Test]
        public void Should_Fail_When_File_Contains_No_Valid_Floating_Point_Numbers()
        {
            var doubleParser = new FakeDoubleParser();
            doubleParser.Setup(fakedReadLines: new List<string>());

            var doubleListResultForEmptyList = doubleParser.GetDoubles();

            Assert.IsTrue(doubleListResultForEmptyList.IsFailure);
            StringAssert.Contains("There's no valid doubles in file", doubleListResultForEmptyList.Error);

            doubleParser.Setup(fakedReadLines: new List<string> { "a", "b", "d", "30.y2" });


            var doubleListResult = doubleParser.GetDoubles();

            Assert.IsTrue(doubleListResult.IsFailure);
            StringAssert.Contains("There's no valid doubles in file", doubleListResult.Error);
        }
    }
}
