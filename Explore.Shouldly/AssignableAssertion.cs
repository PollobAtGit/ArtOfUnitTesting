using AutoFixture.Xunit2;
using Explore.Model.Model;
using Explore.Model.Repository;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    // ReSharper disable once InconsistentNaming
    public class AssignableAssertion
    {
        [Theory, AutoData]
        public void Shouldly_ShouldBeAssignableTo_Should_Detect_Base_Derived_Relation_Properly(Png image)
        {
            image.ShouldNotBeNull();
            image.ShouldBeAssignableTo<Repository>();
        }

        [Theory, AutoData]
        public void Shouldly_ShouldNotBeAssignableTo_Should_Detect_Base_Derived_Relation_Properly(Png image)
        {
            image.ShouldNotBeNull();
            image.ShouldNotBeAssignableTo<Image>();
        }

        [Theory, AutoData]
        public void FluentAssertion_BeAssignableTo_Should_Detect_Base_Derived_Relation_Properly(Png image)
        {
            image.Should().NotBeNull();
            image.Should().BeAssignableTo<Repository>();
        }

        [Theory, AutoData]
        public void FluentAssertion_NotBeAssignableTo_Should_Detect_Base_Derived_Relation_Properly(Png image)
        {
            image.Should().NotBeNull();
            image.Should().NotBeAssignableTo<Image>();
        }
    }
}