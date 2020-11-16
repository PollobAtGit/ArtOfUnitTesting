using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Explore.Model.Model
{
    [DebuggerDisplay("{" + nameof(SelectedImage) + "}")]
    public class Gallery
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