using Microsoft.AspNetCore.Mvc;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport(int id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportModel reportDto)
        {
            if (reportDto == null)
            {
                return BadRequest();
            }

            var report = new Report
            {
                Title = reportDto.Title,
                Content = reportDto.Content
            };

            await _reportService.AddReportAsync(report);
            return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(int id, [FromBody] ReportModel reportDto)
        {

            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            report.Title = reportDto.Title;
            report.Content = reportDto.Content;

            await _reportService.UpdateReportAsync(report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            await _reportService.DeleteReportAsync(id);
            return NoContent();
        }
    }

}
