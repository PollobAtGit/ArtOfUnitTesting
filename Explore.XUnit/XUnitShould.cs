using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Explore.XUnit
{
    // ReSharper disable once InconsistentNaming
    public class FluentAssertionLib_Should
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Detect_Multiple_Instances_Of_List_As_Different()
        {
            var areas = _fixture.CreateMany<Area>().ToList();

            areas.Should().NotBeSameAs(areas.ToList());
        }

        [Fact]
        public void Underlying_Object_Of_A_List_Created_Via_To_List_Is_Same_As_The_Original_One()
        {
            var areas = _fixture.CreateMany<Area>().ToList();
            var expectedList = areas.ToList();

            foreach (var (firstArea, secondArea) in areas.Zip(expectedList))
                ReferenceEquals(firstArea, secondArea).Should().BeTrue();

            areas.Should().Equal(expectedList);
        }

        [Fact]
        public void Compare_Objects_Via_IEquatable_Implementation_When_Equals_Is_Used()
        {
            var areas = _fixture.CreateMany<Area>().ToList();
            var expectedList = areas.DeepClone();

            foreach (var (firstArea, secondArea) in areas.Zip(expectedList))
                ReferenceEquals(firstArea, secondArea).Should().BeFalse();

            areas.Should().Equal(expectedList);
        }
    }
}
