using AutoMapper;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProjectResponseModel> GetProjectByIdAsync(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            return _mapper.Map<ProjectResponseModel>(project);
        }

        public async Task<List<ProjectResponseModel>> GetAllProjectsAsync()
        {
            var project =  await _unitOfWork.Projects.GetAllAsync();
            return _mapper.Map<List<ProjectResponseModel>>(project);
        }

        public async Task AddProjectAsync(ProjectRequestModel projectModel)
        {
            var project = _mapper.Map<Project>(projectModel);
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateProjectAsync(ProjectRequestModel projectModel)
        {
            var existingProject = await _unitOfWork.Projects.GetByIdAsync(projectModel.Id);

            if (existingProject == null)
                throw new KeyNotFoundException("Project not found");

            existingProject.Name = projectModel.Name;
            existingProject.CompanyId = projectModel.CompanyId;

            // Clear existing issues and add the new ones
            existingProject.Issues.Clear();
            foreach (var issueId in projectModel.IssueIds)
            {
                var issue = await _unitOfWork.Issues.GetByIdAsync(issueId);
                if (issue != null)
                {
                    existingProject.Issues.Add(issue);
                }
            }

            // Clear existing employees and add the new ones
            existingProject.Employees.Clear();
            foreach (var employeeId in projectModel.EmployeeIds)
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
                if (employee != null)
                {
                    existingProject.Employees.Add(employee);
                }
            }

            _unitOfWork.Projects.Update(existingProject);
            await _unitOfWork.CommitAsync();
        }


        public async Task DeleteProjectAsync(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.CommitAsync();
        }
    }
}
