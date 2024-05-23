using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Models
{
    public class CompanyRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProjectIds { get; set; } = new List<int>();
    }
}
