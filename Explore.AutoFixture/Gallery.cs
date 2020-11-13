using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Explore.AutoFixture
{
    [DebuggerDisplay("{" + nameof(SelectedImage) + "}")]
    internal class Gallery
    {
        private Image _selectedImage;

        public Image SelectedImage
        {
            get => _selectedImage;
            set
            {
                if (!Images.Contains(value))
                    throw new ArgumentOutOfRangeException(nameof(SelectedImage));

                _selectedImage = value;
            }
        }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}