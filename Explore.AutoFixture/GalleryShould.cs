using System;
using System.Linq;
using Explore.XUnit;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Explore.AutoFixture
{
    public class GalleryShould
    {
        private readonly Fixture _fixture;

        public GalleryShould() => _fixture = new Fixture();

        [Fact]
        public void Throw_Exception_Provided_That_Images_Collection_Doesnt_Not_Contain_Selected_Image()
        {
            var gallery = _fixture
                .Build<Gallery>()
                .Without(x => x.SelectedImage)
                .Create();

            Action act = () => gallery.SelectedImage = new Image();

            act.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Search_For_Settable_Image_In_Images_Collection_By_Value_Not_By_Reference()
        {
            var gallery = _fixture
                .Build<Gallery>()
                .Without(x => x.SelectedImage)
                .Create();

            Action actToCompareByValue = () => gallery.SelectedImage = gallery.Images.First().DeepClone();

            actToCompareByValue.Should().NotThrow();
            gallery.SelectedImage.Should().NotBeNull();
        }
    }
}