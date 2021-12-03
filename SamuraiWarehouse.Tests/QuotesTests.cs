using System.Linq;
using AutoFixture;
using Base.Tests;
using Utility;
using Xunit;
using Xunit.Abstractions;

namespace SamuraiWarehouse.Tests
{
    public class QuotesTests : TestSuitBase
    {
        public QuotesTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void Get_Quotes_With_Description()
        {
            // Arrange

            var quotes = Fixture
                .Build<Quote>()
                .Without(x => x.Text) // failure condition
                .Create()
                .WrapInList();

            // Act

            var filteredQuotes = quotes
                .AsQueryable()
                .GetDomainQueries()
                .GetQuotesWithNames()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Empty(filteredQuotes);
        }

        [Fact]
        public void Get_Orphaned_Quotes_Should_Return_Empty()
        {
            // Arrange

            var quotes = Fixture
                .Build<Quote>()
                .With(x => x.Samurai, Fixture.Create<Samurai>()) // success condition
                .Create()
                .WrapInList();

            // Act

            var filteredQuotes = quotes
                .AsQueryable()
                .GetDomainQueries()
                .GetOrphanedQuotes()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Empty(filteredQuotes);
        }

        [Fact]
        public void Get_Orphaned_Quotes_Should_Return_Orphaned_Quotes_Provided_That_There_Exists_Quote_Without_Samurai()
        {
            // Arrange

            var quotes = Fixture
                .Build<Quote>()
                .Without(x => x.Samurai) // failure condition
                .Create()
                .WrapInList();

            // Act

            var filteredQuotes = quotes
                .AsQueryable()
                .GetDomainQueries()
                .GetOrphanedQuotes()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Populated(filteredQuotes);
        }
    }
}