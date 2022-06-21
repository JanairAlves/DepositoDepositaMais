using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/outgoingorders")]
    public class OutgoingOrdersController : ControllerBase
    {
        private readonly IOutgoingOrderService _outgoingOrderService;

        public OutgoingOrdersController(IOutgoingOrderService outgoingOrderService)
        {
            _outgoingOrderService = outgoingOrderService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var outgoingOrders = _outgoingOrderService.GetAll(query);
            return Ok(outgoingOrders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var outgoingOrder = _outgoingOrderService.GetById(id);

            if(outgoingOrder == null)
                return NotFound();

            return Ok(outgoingOrder);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewOutgoingOrderInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
                return BadRequest();

            var id = _outgoingOrderService.CreateNewOutgoingOrder(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOutgoingOrderInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
                return BadRequest();

            _outgoingOrderService.UpdateOutgoingOrder(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _outgoingOrderService.DeleteOutgoingOrder(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Activate(int id)
        {
            _outgoingOrderService.ActivateOutgoingOrder(id);
            return NoContent();
        }
    }
}
