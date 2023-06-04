using CSV_Reader.Entities;
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
        private readonly IWebHostEnvironment _environment;

        public UploadController(CsvService csvService, IProductRepo productRepo, IWebHostEnvironment environment)
        {
            _csvService = csvService;
            _productRepo = productRepo;
            _environment = environment;
        }

        // POST api/<UploadController>
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            _productRepo.CreateDataBase();

            if (_productRepo.GetAll().Any())
            {
                return Conflict("A file was previously been uploaded");
            }

            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file was selected for upload.");
            }

            _csvService.ImportProductsFromCsv(file);

            await Utils.FileHelper.SaveFile(_environment, file);

            return Ok("CSV file imported successfully.");
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutProduct(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file was selected for upload.");
            }

            _productRepo.DropTable("Products");
            _productRepo.CreateDataBase();

            _csvService.ImportProductsFromCsv(file);

            await Utils.FileHelper.SaveFile(_environment, file);

            return Ok("CSV file imported successfully.");
        }
    }
}
