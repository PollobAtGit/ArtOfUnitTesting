using Service.Implementation;

namespace Service.Interface
{
    public interface IFileVerifier
    {
        FileStatus FileStatus { get; set; }

        bool Verify(string fileWithoutExtension);
    }
}