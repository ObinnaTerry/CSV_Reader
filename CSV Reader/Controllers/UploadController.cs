using CSV_Reader.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSV_Reader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly CsvService _csvService;

        public UploadController(IWebHostEnvironment environment, CsvService csvService)
        {
            _environment = environment;
            _csvService = csvService;
        }

        // POST api/<UploadController>
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file was selected for upload.");
            }

            string filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            _csvService.ImportItemsFromCsv(filePath);

            System.IO.File.Delete(filePath);

            return Ok("CSV file imported successfully.");
        }
    }
}
