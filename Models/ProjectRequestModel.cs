namespace NowadaysIssueTracking.Models;

public class ProjectRequestModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CompanyId { get; set; }
    public IList<int> IssueIds { get; set; } = new List<int>();
    public IList<int> EmployeeIds { get; set; } = new List<int>();
}