using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest(createProject);
            }

            createProject.SetId(1);

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (string.IsNullOrWhiteSpace(updateProject.Description))
            {
                return BadRequest(updateProject);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> CreateComment(int id, [FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartProject(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> FinishProject(int id)
        {
            return NoContent();
        }
    }
}