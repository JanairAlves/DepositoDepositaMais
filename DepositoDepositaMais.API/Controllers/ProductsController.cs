using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService ;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var products = _productService.GetAll(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProductInputModel inputModel)
        {
            if(inputModel.ProductName.Length > 50)
                return BadRequest();
            
            var id = _productService.CreateNewProduct(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
                return BadRequest();
            
            _productService.UpdateProduct(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Activate(int id)
        {
            _productService.ActivateProduct(id);
            return NoContent();
        }
    }
}
