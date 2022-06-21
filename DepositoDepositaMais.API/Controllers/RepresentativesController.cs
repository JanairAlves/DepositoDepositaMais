using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/representatives")]
    public class RepresentativesController : ControllerBase
    {
        private readonly IRepresentativeService _representativeService;
        public RepresentativesController(IRepresentativeService representativeService)
        {
            _representativeService = representativeService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var representatives = _representativeService.GetAll(query);
            return Ok(representatives);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var representative = _representativeService.GetById(id);

            if(representative == null)
                return NotFound();

            return Ok(representative);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewRepresentativeInputModel inputModel)
        {
            if(inputModel.RepresentativeName.Length > 50)
                return BadRequest();

            var id = _representativeService.CreateNewRepresentative(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}/representative")]
        public IActionResult Put(int id, [FromBody] UpdateRepresentativeInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
                return BadRequest();

            _representativeService.UpdateRepresentative(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _representativeService.DeleteRepresentative(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Activate(int id)
        {
            _representativeService.ActivateRepresentative(id);
            return NoContent();
        }
    }
}
