using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace ArtOfUnitTesting.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ILogFileAnalyzer _logFileAnalyzer;
        private readonly IIntegerParser _integerParser;

        public FilesController(ILogFileAnalyzer logFileAnalyzer, IIntegerParser integerParser)
        {
            _logFileAnalyzer = logFileAnalyzer;
            _integerParser = integerParser;
        }

        [HttpGet("{fileToVerify}")]
        public IActionResult Verify(string fileToVerify)
        {
            _logFileAnalyzer.ValidateFile(fileToVerify);
            return Ok(_logFileAnalyzer.WasLastFileValid);
        }

        [HttpGet("numbers")]
        public IActionResult GetParsedNumbers()
        {
            var numberListResult = _integerParser.GetIntegers();

            if (numberListResult.IsFailure)
                return NoContent();

            return Ok(numberListResult.Value);
        }
    }
}