using ApiControlUsers.Models;
using ApiControlUsers.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ApiControlUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _ofWork;

        public ProjectsController(IUnitOfWork contex)
        {
            _ofWork = contex;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAsync()
        {
            var projects = await _ofWork.ProjectRepository.Get().ToListAsync();
            if (projects.Count == 0)
            {
                return NoContent();
            }
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostAsync(Project project)
        {
            _ofWork.ProjectRepository.Add(project);
            await _ofWork.Commit();

            return StatusCode(StatusCodes.Status201Created, project);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Project>> PutAsync(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }
            _ofWork.ProjectRepository.Update(project);
            await _ofWork.Commit();

            return Ok(project);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var project = await _ofWork.ProjectRepository.GetById(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            _ofWork.ProjectRepository.Delete(project);
            await _ofWork.Commit();

            return Ok();
        }
    }
}
