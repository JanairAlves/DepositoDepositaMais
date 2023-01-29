using DepositoDepositaMais.Application.Commands.ActivateRepresentative;
using DepositoDepositaMais.Application.Commands.CreateRepresentative;
using DepositoDepositaMais.Application.Commands.DeleteRepresentative;
using DepositoDepositaMais.Application.Commands.UpdateRepresentative;
using DepositoDepositaMais.Application.Queries.GetAllRepresentatives;
using DepositoDepositaMais.Application.Queries.GetRepresentativeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/representatives")]
    public class RepresentativesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RepresentativesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllRepresentativeQuery = new GetAllRepresentativesQuery(query);

            var representatives = await _mediator.Send(getAllRepresentativeQuery);
            
            return Ok(representatives);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getRepresentativeByIdQuery = new GetRepresentativeByIdQuery(id);

            var representative = await _mediator.Send(getRepresentativeByIdQuery);

            if(representative == null)
                return NotFound();

            return Ok(representative);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRepresentativeCommand command)
        {
            if(command.RepresentativeName.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/representative")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRepresentativeCommand command)
        {
            if(command.Description.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRepresentativeCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateRepresentativeCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
