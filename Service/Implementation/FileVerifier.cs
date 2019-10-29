using System.Collections.Generic;
using Service.Interface;

namespace Service.Implementation
{
    public class FileVerifier : IFileVerifier
    {
        private readonly List<string> _allowedPrefix = new List<string> { "a.", "z." };

        public FileStatus FileStatus { get; set; }

        public bool Verify(string fileWithoutExtension) => _allowedPrefix.Contains(fileWithoutExtension);
    }
}