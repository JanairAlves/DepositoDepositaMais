using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/incomingorders")]
    public class IncomingOrdersController : ControllerBase
    {
        private readonly IIncomingOrderService _incomingOrderService;

        public IncomingOrdersController(IIncomingOrderService incomingOrderService)
        {
            _incomingOrderService = incomingOrderService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var incomingOrders = _incomingOrderService.GetAll(query);
            return Ok(incomingOrders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var incomingOrder = _incomingOrderService.GetById(id);

            if(incomingOrder == null)
                return NotFound();

            return Ok(incomingOrder);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewIncomingOrderInputModel inputModel)
        {
            if (inputModel.Description.Length > 50)
                return BadRequest();

            var id = _incomingOrderService.CreateNewIncomingOrder(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateIncomingOrderInputModel inputModel)
        {
            if (inputModel.Description.Length > 20)
                return BadRequest();

            _incomingOrderService.UpdateIncomingOrder(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _incomingOrderService.DeleteIncomingOrder(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Activate(int id)
        {
            _incomingOrderService.ActivateIncomingOrder(id);
            return NoContent();
        }
    }
}
