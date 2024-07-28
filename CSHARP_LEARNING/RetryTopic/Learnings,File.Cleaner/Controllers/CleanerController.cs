using Microsoft.AspNetCore.Mvc;

namespace Learnings_File.Cleaner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleanerController : ControllerBase
    {
        private readonly ILogger<CleanerController> _logger;
        private static int counter = 10;

        public CleanerController(
            ILogger<CleanerController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CleanText")]
        public IActionResult CleanTextAsync(
            [FromBody] string text, 
            [FromQuery] string replaceWord)
        {
            _logger.LogInformation($"Requested text cleaning...");

            // Fake unstable service
            counter--;
            if (counter != 0) 
            {
                _logger.LogError($"Text cleaning failed!");
                return BadRequest("Error!");
            }
            counter = 10;

            var result = text.Replace(replaceWord, string.Empty);

            _logger.LogInformation($"Text cleaning succeed!");
            return Ok(result);
        }
    }
}
