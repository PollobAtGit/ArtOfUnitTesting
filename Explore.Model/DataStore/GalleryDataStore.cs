using Explore.Model.Repository;

namespace Explore.Model.DataStore
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