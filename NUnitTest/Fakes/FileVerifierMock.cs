using Service.Implementation;
using Service.Interface;

namespace NUnitTest.Fakes
{
    internal class FileVerifierMock : IFileVerifier
    {
        private readonly bool _isValid;

        public FileStatus FileStatus { get; set; }

        public FileVerifierMock(bool isValid)
        {
            _isValid = isValid;
        }

        public bool Verify(string fileWithoutExtension) => _isValid;
    }
}
