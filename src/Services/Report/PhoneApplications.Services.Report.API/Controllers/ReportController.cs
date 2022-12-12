using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using PhoneApplications.Services.Report.Core.Services;
using PhoneApplications.Services.Report.Services.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneApplications.Services.Report.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ICapPublisher _capPublisher;
        public ReportController(IReportService reportService,ICapPublisher capPublisher)
        {
            _reportService = reportService;
            _capPublisher = capPublisher;
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var entity=await _reportService.AddAsync();
            await this._capPublisher.PublishAsync("createdReportRequest", entity.Id);
            return Ok(entity);
        }

        // GET api/<ReportController>/5
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _reportService.GetListAsync());
        }
        [HttpGet("getdetail/{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var entity=await _reportService.GetByIdAsync(id);
            if(entity==null) return NotFound();
            string filepath = $"{Path.GetFullPath("wwwroot")}\\Reports\\{entity.FilePath}";

            if (System.IO.File.Exists(filepath))
                return Ok(await System.IO.File.ReadAllTextAsync(filepath));
            return NotFound("Rapor dosyası bulunamadı"); 
        }

    }
}
