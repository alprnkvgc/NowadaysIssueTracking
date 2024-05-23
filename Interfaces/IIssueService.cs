using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Interfaces;

public interface IIssueService
{
    Task<IssueResponseModel> GetIssueByIdAsync(int id);
    Task<IList<IssueResponseModel>> GetAllIssuesAsync();
    Task AddIssueAsync(IssueRequestModel issue);
    Task UpdateIssueAsync(IssueRequestModel issue);
    Task DeleteIssueAsync(int id);
}