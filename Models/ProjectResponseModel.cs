using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Models;

public class ProjectResponseModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public IList<Issue> Issues { get; set; } = new List<Issue>();
    public IList<Employee> Employees { get; set; }  = new List<Employee>();
}