using AutoFixture;
using Base.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace SamuraiWarehouse.Tests
{
    public class SamuraiTests : TestSuitBase
    {
        public SamuraiTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void Get_Samurai_Quotes_Should_Return_Samurais_With_Quotes()
        {
            // Arrange

            var samurai = Fixture.Create<Samurai>();

            // Act

            // Assert

            OutputHelper.WriteLine(samurai);

            true.ShouldBe(false);
        }
    }
}
