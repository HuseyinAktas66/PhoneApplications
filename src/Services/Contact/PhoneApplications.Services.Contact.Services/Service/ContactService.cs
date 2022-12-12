using AutoMapper;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Entities;
using PhoneApplications.Services.Contact.Core.Repositories;
using PhoneApplications.Services.Contact.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Services.Service
{
    public class ContactService : BaseService<Contacts>, IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _repository;
        public ContactService(IMapper mapper, IContactRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ContactDTO> AddAsync(CreateContactDTO contact)
        {
            var entity = _mapper.Map<Contacts>(contact);

            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;            
            await _repository.AddAsync(entity);

            return _mapper.Map<ContactDTO>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            _repository.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<ContactDTO>> GetAllByPersonId(Guid id)
        {
            return _mapper.Map<List<ContactDTO>>(await _repository.GetByFilterAsync(x => x.PersonId == id));
        }

        public async Task<IEnumerable<ContactDTO>> GetContactTypes()
        {
            return _mapper.Map<List<ContactDTO>>(await _repository.GetContactTypes());
        }
    }
}
