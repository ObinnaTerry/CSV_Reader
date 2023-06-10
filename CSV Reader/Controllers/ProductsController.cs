using Microsoft.AspNetCore.Mvc;
using CSV_Reader.Entities;
using CSV_Reader.Interfaces;

namespace CSV_Reader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productRepo.GetAll().OrderByDescending(x => x.Id));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productRepo.GetByIDAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _productRepo.Update(product);
            _productRepo.Save();

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            _productRepo.Insert(product);
            _productRepo.Save();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIDAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _productRepo.Delete(product);

            return NoContent();
        }

    }
}
