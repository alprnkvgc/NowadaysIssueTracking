namespace NowadaysIssueTracking.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
