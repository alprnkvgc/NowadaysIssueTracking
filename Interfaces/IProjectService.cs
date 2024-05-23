using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Interfaces;

public interface IProjectService
{
    Task<ProjectResponseModel> GetProjectByIdAsync(int id);
    Task<List<ProjectResponseModel>> GetAllProjectsAsync();
    Task AddProjectAsync(ProjectRequestModel projectModel);
    Task UpdateProjectAsync(ProjectRequestModel projectModel);
    Task DeleteProjectAsync(int id);
}