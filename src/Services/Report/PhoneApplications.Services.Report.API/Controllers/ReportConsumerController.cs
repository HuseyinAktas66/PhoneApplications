using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using PhoneApplications.Services.Report.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneApplications.Services.Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportConsumerController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly HttpClient _httpClient; 
        
        public ReportConsumerController(IReportService reportService, HttpClient httpClient)
        {
            _reportService = reportService;            
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"https://localhost:7198/");
        }
        [HttpGet("create")]
        [CapSubscribe("createdReportRequest")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity=await _reportService.GetByIdAsync(id);
            if(entity==null) return NotFound();
            var response = await _httpClient.GetAsync($"api/v1/Person/getreportdata/{id}");
            if (response.IsSuccessStatusCode)
            {
                string path=Path.GetFullPath("wwwroot");
                string filename = $"{id}.json";
                await System.IO.File.WriteAllBytesAsync(path+"\\Reports\\"+filename, await response.Content.ReadAsByteArrayAsync());
                await _reportService.CompleteReport(id, filename);
                return Ok();
            }
            return NotFound();    
            
        }

        
    }
}
