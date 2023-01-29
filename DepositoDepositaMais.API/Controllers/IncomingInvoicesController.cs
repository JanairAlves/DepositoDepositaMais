using DepositoDepositaMais.Application.Commands.ActivateCategory;
using DepositoDepositaMais.Application.Commands.CreateIncomingInvoice;
using DepositoDepositaMais.Application.Commands.DeleteIncomingInvoice;
using DepositoDepositaMais.Application.Commands.UpdateIncomingInvoice;
using DepositoDepositaMais.Application.Queries.GetAllIncomingInvoices;
using DepositoDepositaMais.Application.Queries.GetIncomingInvoiceById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/incominginvoices")]
    public class IncomingInvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IncomingInvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllIncomingInvoicesQuery = new GetAllIncomingInvoicesQuery(query);

            var incomingInvoices = await _mediator.Send(getAllIncomingInvoicesQuery);

            return Ok(incomingInvoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getIncomingInvoiceByIdQuery = new GetIncomingInvoiceByIdQuery(id);

            var incomingInvoice = await _mediator.Send(getIncomingInvoiceByIdQuery);
            
            if(incomingInvoice == null) 
                return NotFound();

            return Ok(incomingInvoice);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIncomingInvoiceCommand command)
        {
            if (command.CarrierName.Length > 50 && command.CompanyName.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateIncomingInvoiceCommand command)
        {
            if(command.Description.Length > 200)
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
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateCategoryCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
