using DepositoDepositaMais.Application.Commands.ActivateStorageLocation;
using DepositoDepositaMais.Application.Commands.CreateStorageLocation;
using DepositoDepositaMais.Application.Commands.DeleteStorageLocation;
using DepositoDepositaMais.Application.Commands.UpdateStorageLocation;
using DepositoDepositaMais.Application.Queries.GetAllStorageLocations;
using DepositoDepositaMais.Application.Queries.GetStorageLocationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/StorageLocations")]
    public class StorageLocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StorageLocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllStorageLocationsQuery = new GetAllStorageLocationsQuery(query);

            var storageLocations = await _mediator.Send(getAllStorageLocationsQuery);

            return Ok(storageLocations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getStorageLocationByIdQuery = new GetStorageLocationByIdQuery(id);

            var StorageLocation = await _mediator.Send(getStorageLocationByIdQuery);
            if(StorageLocation == null)
                return NotFound();

            return Ok(StorageLocation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStorageLocationCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStorageLocationCommand command)
        {
            if (command.Street.Length > 200)
                return BadRequest();

            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteStorageLocationCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateStorageLocationCommand(id);

            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
