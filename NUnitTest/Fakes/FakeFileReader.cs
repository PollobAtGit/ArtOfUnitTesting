using System;
using System.Collections.Generic;
using System.IO;
using Service.Interface;

namespace NUnitTest.Fakes
{
    class FakeConfigurationIsEmptyFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => new List<string>();
    }

    class FakeDefaultConfigurationFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => new List<string>()
        {
            ".slf",
            ".sln"
        };
    }

    class FakeConfigurationFileIsMissingFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => throw new FileNotFoundException();
    }

    class FakeConfigurableFileReader : IFileReader
    {
        private readonly Exception _exceptionToThrow;
        private readonly List<string> _fakedReadLines;

        public FakeConfigurableFileReader(Exception exceptionToThrow = null, List<string> fakedReadLines = null)
        {
            _exceptionToThrow = exceptionToThrow;
            _fakedReadLines = fakedReadLines;
        }

        public List<string> GetAllLines(string fileWithOutPath)
        {
            if (_exceptionToThrow != null)
                throw _exceptionToThrow;

            return _fakedReadLines;
        }
    }
}
