using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest(createProject);
            }

            createProject.SetId(1);

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (string.IsNullOrWhiteSpace(updateProject.Description))
            {
                return BadRequest(updateProject);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult CreateComment(int id, [FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult StartProject(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult FinishProject(int id)
        {
            return NoContent();
        }
    }
}