using Explore.AutoFixture.Repository;

namespace Explore.AutoFixture.DataStore
{
    public class GalleryDataStore
    {
        public IRepository ImageRepository { get; }

        public IRepository CatalogRepository { get; }

        public GalleryDataStore(IRepository catalogRepository, IRepository imageRepository)
        {
            CatalogRepository = catalogRepository;
            ImageRepository = imageRepository;
        }
    }
}