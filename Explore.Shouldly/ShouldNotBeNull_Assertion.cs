using AutoFixture;
using Explore.Model.DataStore;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    // ReSharper disable once InconsistentNaming
    public class ShouldNotBeNull_Assertion_Should
    {
        private readonly Fixture _fixture;

        public ShouldNotBeNull_Assertion_Should() => _fixture = new Fixture();

        [Fact]
        public void Be_Chained_To_Assert_On_Object_Properties()
        {
            var dataStore = _fixture.Create<DataStore>();

            dataStore
                .ShouldNotBeNull()
                .Repository
                .ShouldNotBeNull()
                .Identifier
                .ShouldBeEmpty();
        }
    }
}