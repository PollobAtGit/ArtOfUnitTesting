using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Base.Tests;
using Utility;
using Xunit;
using Xunit.Abstractions;

namespace SamuraiWarehouse.Tests
{
    public class SamuraiTests : TestSuitBase
    {
        public SamuraiTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void Get_Samurai_Quotes_Should_Return_Samurais_With_Quotes()
        {
            // Arrange

            var samurai = Fixture.Create<Samurai>();

            var samurais = new List<Samurai>
            {
                Fixture
                    .Build<Samurai>()
                    .Without(x => x.Name)
                    .Create(),

                samurai
            };

            // Act

            var filteredSamurais = samurais
                .AsQueryable()
                .GetDomainQueries()
                .GetSamuraiWithNames()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Populated(filteredSamurais)
                .Verify_Value_Matches(() => filteredSamurais.Single().Id, samurai.Id, nameof(Samurai.Id));
        }

        [Fact]
        public void Get_Samurai_With_Battles_Fought_Should_Return_Samurais_Who_Fought_Battles()
        {
            // Arrange

            var samurai = Fixture.Create<Samurai>();

            var samurais = new List<Samurai>
            {
                Fixture
                    .Build<Samurai>()
                    .Without(x => x.SamuraiBattles)
                    .Create(),

                samurai
            };

            // Act

            var filteredSamurais = samurais
                .AsQueryable()
                .GetDomainQueries()
                .GetSamuraiWithNames()
                .GetSamuraiWhoFoughtInBattles()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Populated(filteredSamurais)
                .Verify_Value_Matches(() => filteredSamurais.Single().Id, samurai.Id, nameof(Samurai.Id));
        }

        [Fact]
        public void Get_Samurai_With_Registered_Id_Should_Return_Samurais_Having_Id_Greater_Then_Fifty()
        {
            // Arrange

            const int id = 67;

            var samurais = Fixture
                .Build<Samurai>()
                .With(x => x.Id, id)
                .Create()
                .WrapInList();

            // Act

            var filteredSamurais = samurais
                .AsQueryable()
                .GetDomainQueries()
                .GetRegisteredSamurais()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Populated(filteredSamurais)
                .Verify_Value_Matches(() => filteredSamurais.Single().Id, id, nameof(Samurai.Id));
        }

        [Fact]
        public void Get_Valid_Samurai_Should_Return_Empty_List()
        {
            // Arrange

            var samurais = new List<Samurai>
            {
                Fixture
                    .Build<Samurai>()
                    .With(x => x.Id, 50) // invalid case
                    .With(x => x.SamuraiBattles, Fixture.Create<SamuraiBattle>().WrapInList()) // valid case
                    .With(x => x.Name, Fixture.Create<string>()) // valid case
                    .Create(),

                Fixture
                    .Build<Samurai>()
                    .With(x => x.Id, 51) // valid case
                    .Without(x => x.SamuraiBattles) // invalid case
                    .With(x => x.Name, Fixture.Create<string>()) // valid case
                    .Create(),

                Fixture
                    .Build<Samurai>()
                    .With(x => x.Id, 51) // valid case
                    .With(x => x.SamuraiBattles, Fixture.Create<SamuraiBattle>().WrapInList()) // valid case
                    .Without(x => x.Name) // invalid case
                    .Create(),
            };

            // Act

            var filteredSamurais = samurais
                .AsQueryable()
                .GetDomainQueries()
                .GetSamuraiWithNames()
                .GetSamuraiWhoFoughtInBattles()
                .GetRegisteredSamurais()
                .Queryable
                .ToList();

            // Assert

            Start_Verifying()
                .Verify_Collection_Is_Empty(filteredSamurais);
        }
    }
}
