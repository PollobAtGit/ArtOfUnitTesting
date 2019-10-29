using Service.Implementation;
using Service.Interface;

namespace NUnitTest.Fakes
{
    internal class StubCarManufacturer : CarManufacturer
    {
        private readonly bool _isValidConfiguration;

        public StubCarManufacturer(bool isValidConfiguration)
        {
            _isValidConfiguration = isValidConfiguration;
        }

        // stub without external dependency
        protected override bool IsValidConfiguration(IConfiguration configuration) => _isValidConfiguration;
    }
}
