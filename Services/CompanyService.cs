using AutoMapper;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyResponseModel> GetCompanyByIdAsync(int id)
        {

            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            return _mapper.Map<CompanyResponseModel>(company);
        }

        public async Task<List<CompanyResponseModel>> GetAllCompaniesAsync()
        {
            var companies =  await _unitOfWork.Companies.GetAllAsync();

            return _mapper.Map<List<CompanyResponseModel>>(companies);
        }

        public async Task AddCompanyAsync(CompanyRequestModel companyModel)
        {
            var company = _mapper.Map<Company>(companyModel);
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCompanyAsync(CompanyRequestModel companyModel)
        {
            var existingCompany = await _unitOfWork.Companies.GetByIdAsync(companyModel.Id);

            if (existingCompany == null)
                throw new KeyNotFoundException("Company not found");

            existingCompany.Name = companyModel.Name;

            existingCompany.Projects.Clear();
            foreach (var projectId in companyModel.ProjectIds)
            {
                var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
                if (project != null)
                {
                    existingCompany.Projects.Add(project);
                }
            }

            _unitOfWork.Companies.Update(existingCompany);
            await _unitOfWork.CommitAsync();
        }


        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company != null)
            {
                _unitOfWork.Companies.Delete(company);
                await _unitOfWork.CommitAsync();
            }
        }
    }

}
