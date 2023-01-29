using DepositoDepositaMais.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/Skills")]
    public class SkillsControler : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsControler(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllSkillsQuery = new GetAllSkillsQuery();

            var skills = await _mediator.Send(getAllSkillsQuery);

            return Ok(skills);
        }
    }
}
