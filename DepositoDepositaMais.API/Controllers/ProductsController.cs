using DepositoDepositaMais.Application.Commands.ActivateProduct;
using DepositoDepositaMais.Application.Commands.CreateProduct;
using DepositoDepositaMais.Application.Commands.DeleteProduct;
using DepositoDepositaMais.Application.Commands.UpdateProduct;
using DepositoDepositaMais.Application.Queries.GetAllProducts;
using DepositoDepositaMais.Application.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProductsQuery = new GetAllProductsQuery(query);

            var products = await _mediator.Send(getAllProductsQuery);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id);

            var product = await _mediator.Send(getProductByIdQuery);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            if(command.ProductName.Length > 50)
                return BadRequest();
            
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
        {
            if(command.Description.Length > 200)
                return BadRequest();
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateProductCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
