using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace ArtOfUnitTesting.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ILogFileAnalyzer _logFileAnalyzer;

        public FilesController(ILogFileAnalyzer logFileAnalyzer)
        {
            _logFileAnalyzer = logFileAnalyzer;
        }

        [HttpGet("{fileToVerify}")]
        public IActionResult GetAllAsync(string fileToVerify)
        {
            _logFileAnalyzer.ValidateFile(fileToVerify);
            return Ok(_logFileAnalyzer.WasLastFileValid);
        }
    }
}