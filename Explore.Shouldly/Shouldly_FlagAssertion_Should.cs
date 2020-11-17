using AutoFixture;
using Explore.Model.Model;
using Shouldly;
using Shouldly.ShouldlyExtensionMethods;
using Xunit;

namespace Explore.Shouldly
{
    // ReSharper disable once InconsistentNaming
    public class Shouldly_FlagAssertion_Should
    {
        private readonly Fixture _fixture;

        public Shouldly_FlagAssertion_Should() => _fixture = new Fixture();

        [Fact]
        public void Assert_Enum_Flag_Individually()
        {
            // AutoFixture configures properties with fake data and it is done after object creation meaning default values are ignored if there's a setter
            var path = _fixture.Create<Path>();

            path.ShouldNotBeNull();

            path.Os.ShouldHaveFlag(Os.Linux);
            path.Os.ShouldHaveFlag(Os.FreeBsd);
        }

        [Fact]
        public void Assert_Enum_Flag_Combined_Value()
        {
            // AutoFixture configures properties with fake data and it is done after object creation meaning default values are ignored if there's a setter
            var path = _fixture.Create<Path>();

            path.ShouldNotBeNull();

            path.Os.ShouldBe(Os.Linux | Os.FreeBsd);

            //path.Os.ShouldHaveFlag(Os.Linux | Os.FreeBsd); // works also!
        }

        [Fact]
        public void Fail_Enum_Flag_Assertion_With_Better_Message()
        {
            var path = _fixture.Create<Path>();

            path.ShouldNotBeNull();

            path.Os.ShouldHaveFlag(Os.Windows);
        }
    }
}