using System.Collections.Generic;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class SequenceComparison
    {
        [Fact]
        public void Fluent_Assertion_Should_Fail_While_Asserting_Sequence_By_Value() => new List<string> { "apple", "orange", "guava" }.Should().BeEquivalentTo(new List<string> { "apple", "guava" });

        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_While_Asserting_Sequence_By_Value() => new List<string> { "apple", "orange", "guava" }.ShouldBe(new List<string> { "apple", "guava" });

        [Fact]
        public void Fluent_Assertion_Should_Fail_While_Asserting_Ascending_Order_Of_Sequence() => new List<string> { "apple", "orange", "guava" }.Should().BeInAscendingOrder();

        [Fact]
        public void Shouldly_Should_Fail_With_Better_Failure_Assertion_Message_While_Asserting_Ascending_Order_Of_Sequence() => new List<string> { "apple", "orange", "guava" }.ShouldBeInOrder(SortDirection.Ascending);

        [Fact]
        public void Shouldly_Should_Find_Given_Value_Within_A_List() => "guava".Should().BeOneOf(new List<string> { "apple", "orange" });

        [Fact]
        public void Fluent_Assertion_Should_Find_Given_Value_Within_A_List()
        {
            "guava".ShouldBeOneOf(new List<string> { "apple", "orange" }.ToArray());
        }
    }
}
