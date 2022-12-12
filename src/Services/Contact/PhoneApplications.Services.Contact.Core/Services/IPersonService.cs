using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.Services
{
    public interface IPersonService: IBaseService<Persons>
    {
        Task<PersonDTO> UpdateAsync(PersonDTO person);
        Task<PersonDTO> AddAsync(CreatePersonDTO person);

        Task<IEnumerable<PersonDTO>> GetListAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ReportDataDTO>> GetReportDataAsync();
    }
}
