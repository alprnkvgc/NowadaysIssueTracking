using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Models;

public class IssueRequestModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public List<int> AssignedEmployeeIds { get; set; } = new List<int>();
}