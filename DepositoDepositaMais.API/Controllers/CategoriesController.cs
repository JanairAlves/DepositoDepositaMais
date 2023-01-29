using DepositoDepositaMais.Application.Commands.ActivateCategory;
using DepositoDepositaMais.Application.Commands.CreateCategory;
using DepositoDepositaMais.Application.Commands.DeleteCategory;
using DepositoDepositaMais.Application.Commands.UpdateCategory;
using DepositoDepositaMais.Application.Queries.GetAllCategories;
using DepositoDepositaMais.Application.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllCategoriesQuery = new GetAllCategoriesQuery(query);

            var categories = await _mediator.Send(getAllCategoriesQuery);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getCategoryByIdQuery = new GetCategoryByIdQuery(id);
            
            var category = await _mediator.Send(getCategoryByIdQuery);            

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryCommand command)
        {
            if(command.CategoryName.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryCommand command)
        {
            if(command.Description.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateCategoryCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
