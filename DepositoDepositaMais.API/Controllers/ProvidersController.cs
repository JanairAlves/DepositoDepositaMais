using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;
        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var prividers = _providerService.GetAll(query);
            return Ok(prividers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var provider = _providerService.GetById(id);

            if (provider == null)
                return NotFound();

            return Ok(provider);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProviderInputModel inputModel)
        {
            if (inputModel.ProviderName.Length > 50) 
                return BadRequest();
            
            var id = _providerService.CreateNewProvider(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}/provider")]
        public IActionResult Put(int id, [FromBody] UpdateProviderInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
                return BadRequest();

            _providerService.UpdateProvider(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _providerService.DeleteProvider(id);
            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public IActionResult Activate(int id)
        {
            _providerService.ActivateProvider(id);
            return NoContent();
        }
    }
}
