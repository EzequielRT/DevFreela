using DevFreela.Application.Queries.SkillsQueries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{

    [Route("api/skills")]
    public class SkillsController : Controller
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _mediator.Send(new GetAllSkillsQuery());

            return Ok(skills);
        }
    }
}