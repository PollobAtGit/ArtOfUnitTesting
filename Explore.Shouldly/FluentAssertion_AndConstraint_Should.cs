using AutoFixture;
using Explore.Model.DataStore;
using Explore.Model.Repository;
using FluentAssertions;
using Xunit;

namespace Explore.Shouldly
{
    // ReSharper disable once InconsistentNaming
    public class FluentAssertion_AndConstraint_Should
    {
        private readonly Fixture _fixture;

        public FluentAssertion_AndConstraint_Should() => _fixture = new Fixture();

        [Fact]
        public void Be_Chained_To_Assert_On_Object_Properties()
        {
            var dataStore = _fixture.Create<DataStore>();

            dataStore.Should().NotBeNull()
                .And.Subject.As<DataStore>()
                .Repository.Should().NotBeNull()
                .And.Subject.As<Repository>()
                .Identifier.Should().BeEmpty();
        }
    }
}