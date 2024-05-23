namespace NowadaysIssueTracking.Domain;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}