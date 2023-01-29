using DepositoDepositaMais.Application.Commands.ActivateIncomingOrder;
using DepositoDepositaMais.Application.Commands.CreateIncomingOrder;
using DepositoDepositaMais.Application.Commands.DeleteIncomingInvoice;
using DepositoDepositaMais.Application.Commands.UpdateIncomingOrder;
using DepositoDepositaMais.Application.Queries.GetAllIncomingOrders;
using DepositoDepositaMais.Application.Queries.GetIncomingOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/incomingorders")]
    public class IncomingOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IncomingOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllIncomingOrdersQuery = new GetAllIncomingOrdersQuery(query);

            var incomingOrders = await _mediator.Send(getAllIncomingOrdersQuery);

            return Ok(incomingOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getIncomingOrderByIdQuery = new GetIncomingOrderByIdQuery(id);
            
            var incomingOrder = await _mediator.Send(getIncomingOrderByIdQuery);

            if (incomingOrder == null)
                return NotFound();

            return Ok(incomingOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIncomingOrderCommand command)
        {
            if (command.Description.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateIncomingOrderCommand command)
        {
            if (command.Description.Length > 20)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteIncomingInvoiceCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public  async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateIncomingOrderCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
