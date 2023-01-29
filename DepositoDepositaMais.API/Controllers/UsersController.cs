using DepositoDepositaMais.Application.Commands.ActivateUser;
using DepositoDepositaMais.Application.Commands.CreateUser;
using DepositoDepositaMais.Application.Commands.DeleteUser;
using DepositoDepositaMais.Application.Commands.UpdateUser;
using DepositoDepositaMais.Application.Queries.GetAllUsers;
using DepositoDepositaMais.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllUsersQuery = new GetAllUsersQuery(query);

            var users = await _mediator.Send(getAllUsersQuery);
            
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getUserByIdQuery = new GetUserByIdQuery(id);

            var user = await _mediator.Send(getUserByIdQuery);

            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            if(command.FullName.Length > 50)
                return BadRequest();

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/login")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            if (command.FullName.Length > 50)
                return BadRequest();

            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
