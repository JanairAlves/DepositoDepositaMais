using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/outgoinginvoices")]
    public class OutgoingInvoicesController : ControllerBase
    {
        private readonly IOutgoingInvoiceService _outgoingInvoiceService;
        public OutgoingInvoicesController(IOutgoingInvoiceService outgoingInvoiceService)
        {
            _outgoingInvoiceService = outgoingInvoiceService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var outgoingInvoices = _outgoingInvoiceService.GetAll(query);
            return Ok(outgoingInvoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var outgoingInvoiceService = _outgoingInvoiceService.GetById(id);

            if(outgoingInvoiceService == null)
                return NotFound();

            return Ok(outgoingInvoiceService);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewOutgoingInvoiceInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
                return BadRequest();
            
            var id = _outgoingInvoiceService.CreateNewOutgoingInvoice(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, [FromBody] UpdateOutgoingInvoiceInputModel inputModel )
        {
            if (inputModel.Description.Length > 200)
                return BadRequest();

            _outgoingInvoiceService.UpdateOutgoingInvoice(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _outgoingInvoiceService.DeleteOutgoingInvoice(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Activate(int id)
        {
            _outgoingInvoiceService.ActivateOutgoingInvoice(id);
            return NoContent();
        }

    }
}
