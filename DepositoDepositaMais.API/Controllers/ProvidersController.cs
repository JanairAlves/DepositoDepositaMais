using DepositoDepositaMais.Application.Commands.ActivateProvider;
using DepositoDepositaMais.Application.Commands.CreateProvider;
using DepositoDepositaMais.Application.Commands.DeleteProvider;
using DepositoDepositaMais.Application.Commands.UpdateProvider;
using DepositoDepositaMais.Application.Queries.GetAllProviders;
using DepositoDepositaMais.Application.Queries.GetProviderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProvidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProvidersQuery = new GetAllProvidersQuery(query);

            var prividers = await _mediator.Send(getAllProvidersQuery);

            return Ok(prividers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProviderByIdQuery = new GetProviderByIdQuery(id);

            var provider = await _mediator.Send(getProviderByIdQuery);

            if (provider == null)
                return NotFound();

            return Ok(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProviderCommand command)
        {
            if (command.ProviderName.Length > 50) 
                return BadRequest();
            
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/provider")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProviderCommand command)
        {
            if(command.Description.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProviderCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateProviderCommand(id);

            await _mediator.Send(command);


            return NoContent();
        }
    }
}
