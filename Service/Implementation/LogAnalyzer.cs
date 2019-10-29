using System.IO;
using Service.Interface;

namespace Service.Implementation
{
    public class LogAnalyzer : ILogFileAnalyzer
    {
        private readonly IFileVerifier _fileVerifier;

        public bool WasLastFileValid { get; set; }

        public LogAnalyzer(IFileVerifier fileVerifier)
        {
            _fileVerifier = fileVerifier;
        }

        public void ValidateFile(string file)
        {
            WasLastFileValid = !string.IsNullOrEmpty(Path.GetExtension(file));
            _fileVerifier.FileStatus = _fileVerifier.Verify(Path.GetFileNameWithoutExtension(file))
                ? FileStatus.Valid
                : FileStatus.Invalid;
        }
    }
}