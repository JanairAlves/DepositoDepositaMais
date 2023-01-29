using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.Commands.ActivateOutgoingInvoice;
using DepositoDepositaMais.Application.Commands.CreateOutgoingInvoice;
using DepositoDepositaMais.Application.Commands.DeleteOutgoingInvoice;
using DepositoDepositaMais.Application.Commands.UpdateOutgoingInvoice;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Queries.GetAllOutgoingInvoices;
using DepositoDepositaMais.Application.Queries.GetOutgoingInvoiceById;
using DepositoDepositaMais.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/outgoinginvoices")]
    public class OutgoingInvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OutgoingInvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllOutgoingInvoiceQuery = new GetAllOutgoingInvoicesQuery(query);

            var outgoingInvoices = await _mediator.Send(getAllOutgoingInvoiceQuery);

            return Ok(outgoingInvoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getOutgoingInvoiceByIdQuery = new GetOutgoingInvoiceByIdQuery(id);

            var outgoingInvoiceService = await _mediator.Send(getOutgoingInvoiceByIdQuery);

            if(outgoingInvoiceService == null)
                return NotFound();

            return Ok(outgoingInvoiceService);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOutgoingInvoiceCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, [FromBody] UpdateOutgoingInvoiceCommand command)
        {
            if (command.Description.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOutgoingInvoiceCommand(id);

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
