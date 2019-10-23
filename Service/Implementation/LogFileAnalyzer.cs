using System;
using System.Linq;
using Service.Interface;

namespace Service.Implementation
{
    public class LogFileAnalyzer : ILogFileAnalyzer
    {
        private readonly IFileReader _fileReader;
        public const string ConfigurationFile = "allowed-extensions.txt";

        public bool WasLastFileValid { get; set; }

        public LogFileAnalyzer(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void ValidateFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException($"File must be given to validate file");

            WasLastFileValid = _fileReader.GetAllLines(ConfigurationFile).Any(file.EndsWith);
        }
    }
}
