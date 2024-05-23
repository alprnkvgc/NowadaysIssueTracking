using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Interfaces;

public interface ICompanyService
{
    Task<CompanyResponseModel> GetCompanyByIdAsync(int id);
    Task<List<CompanyResponseModel>> GetAllCompaniesAsync();
    Task AddCompanyAsync(CompanyRequestModel company);
    Task UpdateCompanyAsync(CompanyRequestModel company);
    Task DeleteCompanyAsync(int id);
}