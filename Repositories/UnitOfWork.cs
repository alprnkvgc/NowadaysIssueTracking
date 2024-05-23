using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;

namespace NowadaysIssueTracking.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NowadaysDbContext _context;
        private Repository<Company> _companies;
        private Repository<Project> _projects;
        private Repository<Employee> _employees;
        private Repository<Issue> _issues;
        private Repository<Report> _reports;

        public UnitOfWork(NowadaysDbContext context)
        {
            _context = context;
        }

        public IRepository<Company> Companies => _companies ??= new Repository<Company>(_context);
        public IRepository<Project> Projects => _projects ??= new Repository<Project>(_context);
        public IRepository<Employee> Employees => _employees ??= new Repository<Employee>(_context);
        public IRepository<Issue> Issues => _issues ??= new Repository<Issue>(_context);
        public IRepository<Report> Reports => _reports ??= new Repository<Report>(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
