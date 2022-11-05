using DevFreela.API.Models;
using DevFreela.Application.Commands.UserCommands.CreateUser;
using DevFreela.Application.Queries.UserQueries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= decimal.Zero)
                return BadRequest();

            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/login")]
        public async Task<IActionResult> Login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }
    }
}