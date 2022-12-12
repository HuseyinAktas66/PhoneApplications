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
    public interface IContactService: IBaseService<Contacts> 
    {
        Task<IEnumerable<ContactDTO>> GetAllByPersonId(Guid id);

        Task<ContactDTO> AddAsync(CreateContactDTO contact);

        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ContactDTO>> GetContactTypes();
    }
}
