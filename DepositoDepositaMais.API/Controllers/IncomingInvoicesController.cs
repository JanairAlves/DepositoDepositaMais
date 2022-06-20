using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/incominginvoices")]
    public class IncomingInvoicesController : ControllerBase
    {
        private readonly IIncomingInvoiceService _incomingInvoiceService;

        public IncomingInvoicesController(IIncomingInvoiceService incomingInvoiceService)
        {
            _incomingInvoiceService = incomingInvoiceService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var incomingInvoices = _incomingInvoiceService.GetAll(query);
            return Ok(incomingInvoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var incomingInvoice = _incomingInvoiceService.GetById(id);
            
            if(incomingInvoice == null) 
                return NotFound();

            return Ok(incomingInvoice);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewIncomingInvoiceInputModel inputModel)
        {
            if (inputModel.CarrierName.Length > 50 && inputModel.CompanyName.Length > 50)
                return BadRequest();

            var id = _incomingInvoiceService.CreateNewIncomingInvoice(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateIncomingInvoiceInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
                return BadRequest();

            _incomingInvoiceService.UpdateIncomingInvoice(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _incomingInvoiceService.DeleteIncomingInvoice(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Activate(int id)
        {
            _incomingInvoiceService.ActivateIncomingInvoice(id);
            return NoContent();
        }
    }
}
