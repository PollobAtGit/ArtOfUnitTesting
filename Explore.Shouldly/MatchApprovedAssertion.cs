using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class MatchApprovedAssertion
    {
        [Fact]
        public void Shouldly_Should_Provide_Better_Failure_Message_For_Approval_Testing()
        {
            var quotes = "Hi Super Nintendo Chalmes";
            quotes.ShouldMatchApproved(x =>
            {
                x.UseCallerLocation();
                x.SubFolder("Approved");
            });
        }
    }
}
