using DepositoDepositaMais.Application.Commands.ActivateOutgoingInvoice;
using DepositoDepositaMais.Application.Commands.CreateOutgoingOrder;
using DepositoDepositaMais.Application.Commands.DeleteOutgoingOrder;
using DepositoDepositaMais.Application.Commands.UpdateOutgoingOrder;
using DepositoDepositaMais.Application.Queries.GetAllOutgoingOrders;
using DepositoDepositaMais.Application.Queries.GetOutgoingOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/outgoingorders")]
    public class OutgoingOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OutgoingOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllOutgoingOrdesQuery = new GetAllOutgoingOrdersQuery(query);

            var outgoingOrders = await _mediator.Send(getAllOutgoingOrdesQuery);

            return Ok(outgoingOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getOutgoingOrderByIdQuery = new GetOutgoingOrderByIdQuery(id);

            var outgoingOrder = await _mediator.Send(getOutgoingOrderByIdQuery);

            if(outgoingOrder == null)
                return NotFound();

            return Ok(outgoingOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOutgoingOrderCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOutgoingOrderCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOutgoingOrderCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateOutgoingInvoiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
