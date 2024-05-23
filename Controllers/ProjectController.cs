using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;
using NowadaysIssueTracking.Services;

namespace NowadaysIssueTracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IIssueService _issueService;
        private readonly IEmployeeService _employeeService;

        public ProjectController(IProjectService projectService, IIssueService issueService, IEmployeeService employeeService)
        {
            _projectService = projectService;
            _issueService = issueService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRequestModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.AddProjectAsync(projectModel);
            return CreatedAtAction(nameof(GetProjectById), new { id = projectModel.Id }, projectModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectRequestModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectModel.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _projectService.UpdateProjectAsync(projectModel);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
    }



}
