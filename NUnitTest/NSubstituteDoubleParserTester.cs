using NSubstitute;
using NUnit.Framework;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class NSubstituteDoubleParserTester
    {
        [Test]
        public void Should_Fail_When_Reader_Is_Not_Configured()
        {
            var parser = Substitute.For<DoubleParser>();

            parser.GetReader().Returns(null as IFileReader);

            Assert.DoesNotThrow(() => parser.GetDoubles());
        }
    }
}
