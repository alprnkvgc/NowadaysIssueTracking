namespace NowadaysIssueTracking.Domain;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public ICollection<Issue> Issues { get; set; }
    public ICollection<Employee> Employees { get; set; }
}