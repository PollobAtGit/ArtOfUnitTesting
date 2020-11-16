using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class NumericComparison
    {
        [Fact]
        public void Fluent_Assertion_Should_Fail_While_Asserting_Integer() => 20.Should().Be(10);

        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_While_Asserting_Integer() => 20.ShouldBe(10);

        [Fact]
        public void Fluent_Assertion_Should_Fail_While_Asserting_Decimal() => 20m.Should().Be(10m);

        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_While_Asserting_Decimal() => 20m.ShouldBe(10m);

        [Fact]
        public void Fluent_Assertion_Should_Fail_While_Asserting_Double_With_Approximation() => 8.3.Should().BeApproximately(8, 0.3);

        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_While_Asserting_Double_With_Approximation() => 8.3.ShouldBe(8, 0.3);
    }
}