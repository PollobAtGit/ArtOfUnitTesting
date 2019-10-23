using System.Collections.Generic;
using Service.Interface;

namespace NUnitTest.Fakes
{
    class FakeNoConfigurationExistsFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => new List<string>();
    }

    class FakeDefaultConfigurationFileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath) => new List<string>();
    }
}
