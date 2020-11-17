using AutoFixture.Xunit2;
using Explore.Model.Model;
using Explore.Model.Repository;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace Explore.Shouldly
{
    public class TypeDetectionAssertion
    {
        [Theory, AutoData]
        public void Shouldly_Should_Detect_Object_Type(Image image) =>
            image.ShouldBeOfType<Repository>(
                $"{image} is of type [{nameof(Image)}] which is inherited from {nameof(Repository)}");

        [Theory, AutoData]
        public void Fluent_Assertion_Should_Detect_Object_Type(Image image) => image.Should()
            .BeOfType<Repository>($"{image} is of type [{nameof(Image)}] which is inherited from {nameof(Repository)}");
    }
}