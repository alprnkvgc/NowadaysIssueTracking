using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Interfaces;

public interface IReportService
{
    Task<Report> GetReportByIdAsync(int id);
    Task<IEnumerable<Report>> GetAllReportsAsync();
    Task AddReportAsync(Report report);
    Task UpdateReportAsync(Report report);
    Task DeleteReportAsync(int id);
}