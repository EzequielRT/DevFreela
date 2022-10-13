using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var projects = await _projectService.GetAll(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetById(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest(inputModel);
            }

            var id = await _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (string.IsNullOrWhiteSpace(inputModel.Description))
            {
                return BadRequest(inputModel);
            }

            var updateCompleted = await _projectService.Update(inputModel);

            if (updateCompleted)
                return BadRequest(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> CreateComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {
            await _projectService.CreateComment(inputModel);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartProject(int id)
        {
            await _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> FinishProject(int id)
        {
            await _projectService.Finish(id);

            return NoContent();
        }
    }
}