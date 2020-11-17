using AutoFixture;
using Explore.Model.Model;
using FluentAssertions;
using Xunit;

namespace Explore.Shouldly
{
    // ReSharper disable once InconsistentNaming
    public class FluentAssertion_Should
    {
        private readonly Fixture _fixture;

        public FluentAssertion_Should() => _fixture = new Fixture();

        [Fact]
        public void Assert_Enum_Flag_Individually()
        {
            var path = _fixture.Create<Path>();

            path.Should().NotBeNull();

            path.Os.Should().HaveFlag(Os.FreeBsd);
            path.Os.Should().HaveFlag(Os.Linux);
        }

        [Fact]
        public void Assert_Enum_Flag_Combined_Value()
        {
            var path = _fixture.Create<Path>();

            path.Should().NotBeNull();

            path.Os.Should().Be(Os.Linux | Os.FreeBsd);
        }

        [Fact]
        public void Fail_Enum_Flag_Assertion()
        {
            var path = _fixture.Create<Path>();

            path.Should().NotBeNull();

            path.Os.Should().HaveFlag(Os.Windows);
        }
    }
}