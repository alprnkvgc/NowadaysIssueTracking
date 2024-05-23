using NowadaysIssueTracking.Domain;
using NowadaysIssueTracking.Interfaces;

namespace NowadaysIssueTracking.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            return await _unitOfWork.Reports.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _unitOfWork.Reports.GetAllAsync();
        }

        public async Task AddReportAsync(Report report)
        {
            await _unitOfWork.Reports.AddAsync(report);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            _unitOfWork.Reports.Update(report);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteReportAsync(int id)
        {
            var report = await _unitOfWork.Reports.GetByIdAsync(id);
            if (report != null)
            {
                _unitOfWork.Reports.Delete(report);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
