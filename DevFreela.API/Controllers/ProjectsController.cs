using DevFreela.Application.Commands.CommentCommands.CreateComment;
using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Application.Commands.ProjectCommands.DeleteProject;
using DevFreela.Application.Commands.ProjectCommands.FinishProject;
using DevFreela.Application.Commands.ProjectCommands.StartProject;
using DevFreela.Application.Commands.ProjectCommands.UpdateProject;
using DevFreela.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreela.Application.Queries.ProjectQueries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery());

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= decimal.Zero)
                return BadRequest();

            var project = await _mediator.Send(new GetProjectByIdQuery(id));

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        [Authorize("Client")]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
                return BadRequest(command);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut]
        [Authorize("Client")]
        public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Description))
                return BadRequest(command);

            var updated = await _mediator.Send(command);

            if (updated == false)
                return BadRequest(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize("Client")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= decimal.Zero)
                return BadRequest();

            var command = new DeleteProjectCommand(id);

            var deleted = await _mediator.Send(command);

            if (deleted == false)
                return BadRequest(command);

            return NoContent();
        }

        [HttpPost("comments")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == false)
                return BadRequest(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        [Authorize("Client")]
        public async Task<IActionResult> StartProject(int id)
        {
            if (id <= decimal.Zero)
                return BadRequest();

            var command = new StartProjectCommand(id);

            var started = await _mediator.Send(command);

            if (started == false)
                return BadRequest(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize("Client")]
        public async Task<IActionResult> FinishProject(int id, [FromBody] FinishProjectCommand command)
        {
            if (id <= decimal.Zero)
                return BadRequest();

            command.SetProjectId(id);

            await _mediator.Send(command);

            return Accepted();
        }
    }
}