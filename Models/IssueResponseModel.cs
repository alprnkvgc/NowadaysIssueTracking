using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Models;

public class IssueResponseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    public List<Employee> AssignedEmployees { get; set; } = new List<Employee>();
}