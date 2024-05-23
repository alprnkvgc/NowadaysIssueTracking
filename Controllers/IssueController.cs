using Microsoft.AspNetCore.Mvc;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;
using NowadaysIssueTracking.Services;

namespace NowadaysIssueTracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _ıssueService;

        public IssueController(IIssueService ıssueService)
        {
            _ıssueService = ıssueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIssues()
        {
            var ıssues = await _ıssueService.GetAllIssuesAsync();
            return Ok(ıssues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssueById(int id)
        {
            var ıssue = await _ıssueService.GetIssueByIdAsync(id);
            return Ok(ıssue);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] IssueRequestModel ıssueModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ıssueService.AddIssueAsync(ıssueModel);
            return CreatedAtAction(nameof(GetIssueById), new { id = ıssueModel.Id }, ıssueModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(int id, [FromBody] IssueRequestModel issueModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != issueModel.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _ıssueService.UpdateIssueAsync(issueModel);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            await _ıssueService.DeleteIssueAsync(id);
            return NoContent();
        }
    }
}
