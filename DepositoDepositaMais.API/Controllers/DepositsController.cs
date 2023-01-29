using DepositoDepositaMais.Application.Commands.ActivateDeposit;
using DepositoDepositaMais.Application.Commands.CreateDeposit;
using DepositoDepositaMais.Application.Commands.DeleteDeposit;
using DepositoDepositaMais.Application.Commands.UpdateDeposit;
using DepositoDepositaMais.Application.Queries.GetAllDeposits;
using DepositoDepositaMais.Application.Queries.GetDepositById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/deposits")]
    public class DepositsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepositsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllDepositsQuery = new GetAllDepositsQuery(query);

            var deposits = await _mediator.Send(getAllDepositsQuery);

            return Ok(deposits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getDepositByIdQuery = new GetDepositByIdQuery(id);

            var deposit = await _mediator.Send(getDepositByIdQuery);
            
            if(deposit == null) 
                return NotFound();

            return Ok(deposit);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDepositCommand command)
        {
            if (command.DepositName.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDepositCommand command)
        {
            if(command.Description.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDepositCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateDepositCommand(id);

            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
