using Microsoft.AspNetCore.Mvc;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneApplications.Services.Contact.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;   
        }
        [Produces("application/json", "text/plain")]
        [HttpGet("getallbypersonid/{id}")]
        public async Task<IActionResult> GetAllByPersonId(Guid id)
        {
            return Ok(await _contactService.GetAllByPersonId(id));
        }


        [Produces("application/json", "text/plain")]
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateContactDTO contactDTO)
        {            
            return Ok(await _contactService.AddAsync(contactDTO));
        }
        [Produces("application/json", "text/plain")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result =await _contactService.DeleteAsync(id);
            if (result) return Ok(true);
            return BadRequest("Kayıt bulunamadı");
        }
    }
}
