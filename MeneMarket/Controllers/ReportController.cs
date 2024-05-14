using MeneMarket.Models.Foundations.Reports;
using MeneMarket.Services.Foundations.Reports;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : RESTFulController
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService) =>
            this.reportService = reportService;

        [HttpPost]
        public async ValueTask<Report> AddReportAsync(Report report) =>
            await this.reportService.AddReportAsync(report);

        [HttpGet]
        public IQueryable<Report> GetAllReports() =>
            this.reportService.RetrieveAllReports();

        [HttpDelete]
        public async ValueTask<Report> DeleteReportAsync(Guid id) =>
            await this.reportService.RemoveReportAsync(id);
    }
}