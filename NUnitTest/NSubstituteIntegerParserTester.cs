using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class NSubstituteIntegerParserTester
    {
        [Test]
        public void Should_Return_Failure_When_File_Is_Empty()
        {
            var fileReader = Substitute.For<IFileReader>();
            var factory = Substitute.For<IFactory<IFileReader>>();

            fileReader.GetAllLines(Arg.Any<string>()).Returns(new List<string>());

            factory.Instance.Returns(fileReader);

            var parser = new IntegerParser(factory);

            var integersResult = parser.GetIntegers();

            Assert.True(integersResult.IsFailure);
        }

        [Test]
        public void Should_Fail_If_File_Name_For_File_Reader_Is_Empty_Or_Null()
        {
            var fileReader = Substitute.For<IFileReader>();

            fileReader
                .When(x => x.GetAllLines(Arg.Any<string>()))
                .Throw<NullReferenceException>();

            var factory = Substitute.For<IFactory<IFileReader>>();

            var parser = new IntegerParser(factory);

            var integersResult = parser.GetIntegers();

            Assert.IsTrue(integersResult.IsFailure);
            StringAssert.Contains("Reason: ", integersResult.Error);
        }
    }
}
