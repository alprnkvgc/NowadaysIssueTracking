using AutoMapper;
using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Models;

namespace NowadaysIssueTracking.Profiles
{
    public class MappingProfile : Profile
    {
            public MappingProfile()
            {
                // Company mappings
                CreateMap<Company, CompanyResponseModel>()
                    .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.Projects));

                CreateMap<CompanyRequestModel, Company>()
                    .ForMember(dest => dest.Projects, opt => opt.Ignore()); // Projects will be handled manually
                CreateMap<Company, CompanyRequestModel>()
                    .ForMember(dest => dest.ProjectIds, opt => opt.MapFrom(src => src.Projects.Select(p => p.Id)));

                // Project mappings
                CreateMap<Project, ProjectResponseModel>()
                    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

                CreateMap<ProjectRequestModel, Project>()
                    .ForMember(dest => dest.Issues, opt => opt.Ignore()) // Issues will be handled manually
                    .ForMember(dest => dest.Employees, opt => opt.Ignore()); // Employees will be handled manually

                // Issue mappings
                CreateMap<Issue, IssueResponseModel>()
                    .ForMember(dest => dest.AssignedEmployees, opt => opt.MapFrom(src => src.AssignedEmployees.Select(e => e.Id)));

                CreateMap<IssueRequestModel, Issue>()
                    .ForMember(dest => dest.AssignedEmployees, opt => opt.Ignore()); // AssignedEmployees will be handled manually

                // Employee mappings
                CreateMap<Employee, EmployeeResponseModel>();

                CreateMap<EmployeeRequestModel, Employee>()
                    .ForMember(dest => dest.Issues, opt => opt.Ignore()) // Issues will be handled manually
                    .ForMember(dest => dest.Projects, opt => opt.Ignore()); // Projects will be handled manually

                CreateMap<Project, ProjectResponseModel>();
                CreateMap<Issue, IssueResponseModel>();
        }
        

    }
}
