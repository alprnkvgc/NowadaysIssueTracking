using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Company> Companies { get; }
        IRepository<Project> Projects { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Issue> Issues { get; }
        IRepository<Report> Reports { get; }
        Task<int> CommitAsync();
    }

}
