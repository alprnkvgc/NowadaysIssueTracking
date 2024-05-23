using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NowadaysIssueTracking.Interfaces;
using NowadaysIssueTracking.Repositories;
using NowadaysIssueTracking.Services;

namespace NowadaysIssueTracking;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<NowadaysDbContext>(options =>
            options.UseLazyLoadingProxies()
                .UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        services.AddControllers()
            .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
        services.AddAutoMapper(typeof(Startup));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITcKimlikNoValidationService, TcKimlikNoValidationService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IIssueService, IssueService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nowadays API", Version = "v1" });
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nowadays API V1");
        });
    }
}