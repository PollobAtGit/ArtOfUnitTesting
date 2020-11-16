using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class NotNullAssertion
    {
        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_When_Asserting_For_Non_Null_Value()
        {
            NullAssertion na = null;
            na.ShouldNotBeNull();
        }

        [Fact]
        public void Fluent_Assertion_Should_Fail_When_Asserting_For_Non_Null_Value()
        {
            NullAssertion na = null;
            na.Should().NotBeNull();
        }
    }
}