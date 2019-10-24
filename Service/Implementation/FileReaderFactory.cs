using Service.Interface;

namespace Service.Implementation
{
    public class FileReaderFactory : IFactory<IFileReader>
    {
        public virtual IFileReader Instance => new FileReader();
    }
}