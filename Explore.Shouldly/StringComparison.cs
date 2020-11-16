using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class StringComparison
    {
        [Fact]
        public void Fluent_Assertion_Should_Fail_While_Asserting_Strings() => "abc".Should().Be("bc");

        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_While_Asserting_String() => "abc".ShouldBe("bc");
    }
}