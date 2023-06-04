using CSV_Reader.Interfaces;
using CSV_Reader.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSV_Reader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly CsvService _csvService;
        private readonly IProductRepo _productRepo;

        public UploadController(CsvService csvService, IProductRepo productRepo)
        {
            _csvService = csvService;
            _productRepo = productRepo;
        }

        // POST api/<UploadController>
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            if(_productRepo.GetAll().Any())
            {
                return Conflict("A file was previously been uploaded");
            }

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
