using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
    Task<IList<EmployeeResponseModel>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(EmployeeRequestModel employeeModel);
    Task UpdateEmployeeAsync(EmployeeRequestModel employeeModel);
    Task DeleteEmployeeAsync(int id);
}