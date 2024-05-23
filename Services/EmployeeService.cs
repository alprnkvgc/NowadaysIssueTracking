using AutoMapper;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITcKimlikNoValidationService _tcKimlikNoValidationService;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, ITcKimlikNoValidationService tcKimlikNoValidationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tcKimlikNoValidationService = tcKimlikNoValidationService;
            _mapper = mapper;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var employee =  await _unitOfWork.Employees.GetByIdAsync(id);
            return _mapper.Map<EmployeeResponseModel>(employee);
        }

        public async Task<IList<EmployeeResponseModel>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<List<EmployeeResponseModel>>(employees);
        }

        public async Task AddEmployeeAsync(EmployeeRequestModel employeeModel)
        {
            if (!await _tcKimlikNoValidationService.ValidateAsync(employeeModel.TCKimlikNo, employeeModel.FirstName, employeeModel.LastName, employeeModel.BirthYear))
            {
                throw new Exception("Invalid TC Kimlik No");
            }

            var employee = _mapper.Map<Employee>(employeeModel);
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeRequestModel employeeModel)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(employeeModel.Id);

            if (existingEmployee == null)
                throw new KeyNotFoundException("Employee not found");

            existingEmployee.TCKimlikNo = employeeModel.TCKimlikNo;
            existingEmployee.FirstName = employeeModel.FirstName;
            existingEmployee.LastName = employeeModel.LastName;
            existingEmployee.BirthYear = employeeModel.BirthYear;
            

            _unitOfWork.Employees.Update(existingEmployee);
            await _unitOfWork.CommitAsync();
        }


        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee != null)
            {
                _unitOfWork.Employees.Delete(employee);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
