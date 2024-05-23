using AutoMapper;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Services
{
    public class IssueService : IIssueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IssueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IssueResponseModel> GetIssueByIdAsync(int id)
        {

             var issue = await _unitOfWork.Issues.GetByIdAsync(id);
             return _mapper.Map<IssueResponseModel>(issue);
        }

        public async Task<IList<IssueResponseModel>> GetAllIssuesAsync()
        {
            var issue = await _unitOfWork.Issues.GetAllAsync();
            return _mapper.Map<IList<IssueResponseModel>>(issue);
        }

        public async Task AddIssueAsync(IssueRequestModel issueModel)
        {
            var issue = _mapper.Map<Issue>(issueModel);
            await _unitOfWork.Issues.AddAsync(issue);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateIssueAsync(IssueRequestModel issueModel)
        {
            var existingIssue = await _unitOfWork.Issues.GetByIdAsync(issueModel.Id);

            if (existingIssue == null)
                throw new KeyNotFoundException("Issue not found");

            existingIssue.Title = issueModel.Title;
            existingIssue.Description = issueModel.Description;
            existingIssue.ProjectId = issueModel.ProjectId;

            // Clear existing assigned employees and add the new ones
            existingIssue.AssignedEmployees.Clear();
            foreach (var employeeId in issueModel.AssignedEmployeeIds)
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
                if (employee != null)
                {
                    existingIssue.AssignedEmployees.Add(employee);
                }
            }

            _unitOfWork.Issues.Update(existingIssue);
            await _unitOfWork.CommitAsync();
        }


        public async Task DeleteIssueAsync(int id)
        {
            var issue = await _unitOfWork.Issues.GetByIdAsync(id);
            if (issue != null)
            {
                _unitOfWork.Issues.Delete(issue);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
