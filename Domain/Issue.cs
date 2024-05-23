namespace NowadaysIssueTracking.Domain;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    public virtual ICollection<Employee> AssignedEmployees { get; set; } = new List<Employee>();
}