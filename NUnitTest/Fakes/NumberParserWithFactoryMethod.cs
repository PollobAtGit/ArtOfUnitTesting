using System.Collections.Generic;
using Service.Interface;

namespace NUnitTest.Fakes
{
    public class NumberParserWithFactoryMethod : IFactory<IFileReader>
    {
        private readonly bool _isConfigureFileReader;
        private readonly List<string> _fakedReadLines;

        public IFileReader Instance => !_isConfigureFileReader
            ? null
            : new FakeConfigurableFileReader(fakedReadLines: _fakedReadLines);

        public NumberParserWithFactoryMethod(bool isConfigureFileReader = true, List<string> fakedReadLines = null)
        {
            _isConfigureFileReader = isConfigureFileReader;
            _fakedReadLines = fakedReadLines;
        }
    }
}
