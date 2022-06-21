using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/deposits")]
    public class DepositsController : ControllerBase
    {
        private readonly IDepositService _depositService;

        public DepositsController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var deposits = _depositService.GetAll(query);
            return Ok(deposits);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var deposit = _depositService.GetById(id);
            
            if(deposit == null) 
                return NotFound();

            return Ok(deposit);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewDepositInputModel inputModel)
        {
            if (inputModel.DepositName.Length > 50)
                return BadRequest();

            var id = _depositService.CreateNewDeposit(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDepositInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
                return BadRequest();

            _depositService.UpdateDeposit(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _depositService.DeleteDeposit(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Activate(int id)
        {
            _depositService.ActivateDeposit(id);
            return NoContent();
        }
    }
}
