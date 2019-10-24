using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnitTest.Fakes;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class IntegerParserTester
    {
        [Test]
        public void Should_Return_Failure_When_Reader_Is_Not_Configured()
        {
            IIntegerParser integerParser =
                new IntegerParser(new NumberParserWithFactoryMethod(isConfigureFileReader: false));

            Assert.DoesNotThrow(() => integerParser.GetIntegers());
            Assert.IsFalse(integerParser.GetIntegers().IsSuccess);
        }

        [Test]
        public void Should_Return_Failure_When_File_Is_Empty()
        {
            IIntegerParser integerParser =
                new IntegerParser(new NumberParserWithFactoryMethod(fakedReadLines: new List<string>()));

            var numberListResult = integerParser.GetIntegers();

            Assert.IsFalse(numberListResult.IsSuccess);
            StringAssert.Contains("no valid integers", numberListResult.Error);
        }
    }
}
