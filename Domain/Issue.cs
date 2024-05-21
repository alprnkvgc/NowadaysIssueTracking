namespace NowadaysIssueTracking.Domain;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public ICollection<Employee> AssignedEmployees { get; set; }
}