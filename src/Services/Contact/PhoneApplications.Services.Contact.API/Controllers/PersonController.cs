using Microsoft.AspNetCore.Mvc;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneApplications.Services.Contact.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personServices;
        public PersonController(IPersonService personServices)
        {
            _personServices = personServices;
        }
        [Produces("application/json", "text/plain")]
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _personServices.GetListAsync());
        }


        [Produces("application/json", "text/plain")]
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreatePersonDTO model)
        {
           return Ok(await _personServices.AddAsync(model));
        }

        
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] PersonDTO model)
        {
            var result=await _personServices.UpdateAsync(model);
            return Ok(result);
        }

        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result =await _personServices.DeleteAsync(id);
            if(result)  return Ok(true);
            return BadRequest("Kayıt bulunamadı");
        }

        [HttpGet("getreportdata/{id}")]
        public async Task<IActionResult> GetReportData(Guid id)
        {
            var result = await _personServices.GetReportDataAsync();
            if (result==null) return BadRequest("Hata");
            return Ok(result);
        }
    }
}
