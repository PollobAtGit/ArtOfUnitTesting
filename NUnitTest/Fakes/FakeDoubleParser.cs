using System.Collections.Generic;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest.Fakes
{
    public class FakeDoubleParser : DoubleParser
    {
        private bool _isConfigurable;
        private List<string> _fakedReadLines;

        public void Setup(bool isConfigurable = true, List<string> fakedReadLines = null)
        {
            _isConfigurable = isConfigurable;
            _fakedReadLines = fakedReadLines;
        }

        protected override IFileReader GetReader()
        {
            if (!_isConfigurable)
                return null;

            return new FakeConfigurableFileReader(fakedReadLines: _fakedReadLines);
        }
    }
}
