using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Explore.Model.DataStore;
using Explore.Model.Repository;
using FluentAssertions;
using Xunit;

namespace Explore.AutoFixture
{
    public class AutoFixtureWithAutoMoqConfigurationShould
    {
        private readonly Fixture _fixture;

        public AutoFixtureWithAutoMoqConfigurationShould()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization
            {
                ConfigureMembers = true
            });
        }

        [Fact]
        public void Return_The_Freezed_Mock_Instance_Upon_Creation_Of_Sut()
        {
            var repository = _fixture.Freeze<IRepository>();

            var galleryDataStore = _fixture.Create<GalleryDataStore>();

            galleryDataStore.CatalogRepository.Should().BeSameAs(repository);
            galleryDataStore.ImageRepository.Should().BeSameAs(repository);
        }

        [Fact]
        public void Successfully_Create_Moq_Instance_Of_Abstract_Type_Provided_That_Fixture_Is_Customized_With_AutoMoq_When_Requested()
        {
            var repository = _fixture.Freeze<IRepository>();

            var dataStore = _fixture.Create<CatalogDataStore>();

            dataStore.Should().NotBeNull();
            dataStore.Id.Should().NotBe(Guid.Empty);

            dataStore.Repository.Should().NotBeNull();
            dataStore.Repository.Index.Should().NotBe(0);
            dataStore.Repository.Identifier.Should().NotBeEmpty();

            dataStore.Repository.Should().BeSameAs(repository);
        }
    }
}