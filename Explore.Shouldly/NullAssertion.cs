using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class NullAssertion
    {
        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_When_Asserting_For_Null_Value() => new NullAssertion().ShouldBeNull();

        [Fact]
        public void Fluent_Assertion_Should_Fail_When_Asserting_For_Null_Value() => new NullAssertion().Should().BeNull();
    }
}