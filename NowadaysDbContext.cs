using Microsoft.EntityFrameworkCore;
using NowadaysIssueTracking.Domain;

namespace NowadaysIssueTracking
{
    public class NowadaysDbContext : DbContext
    {
        public NowadaysDbContext(DbContextOptions<NowadaysDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Issues)
                .HasForeignKey(i => i.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects);

            modelBuilder.Entity<Issue>()
                .HasMany(i => i.AssignedEmployees)
                .WithMany(e => e.Issues);
        }
    }
}
