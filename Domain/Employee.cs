namespace NowadaysIssueTracking.Domain;

public class Employee
{
    public int Id { get; set; }
    public string TCKimlikNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}