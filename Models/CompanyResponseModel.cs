using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Models
{
    public class CompanyResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectResponseModel> Projects { get; set; } = new List<ProjectResponseModel>();
    }
}
