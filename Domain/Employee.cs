namespace NowadaysIssueTracking.Domain;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TCKimlikNo { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Issue> Issues { get; set; }
}