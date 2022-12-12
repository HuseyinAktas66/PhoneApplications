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
    public class PersonService : BaseService<Persons>, IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _repository;
        public PersonService(IMapper mapper,IPersonRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PersonDTO> UpdateAsync(PersonDTO person)
        {
            var entity=await _repository.GetByIdAsync(person.Id);
            if (entity == null) return person;

            entity.Name = person.Name;
            entity.Surname = person.SurName;
            entity.Company = person.Company;
            entity.LastModifiedDate = DateTime.Now;                
           
            _repository.Update(entity);
            
            return _mapper.Map<PersonDTO>(entity);

        }
        public async Task<PersonDTO> AddAsync(CreatePersonDTO person)
        {
            var entity = _mapper.Map<Persons>(person);
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedDate = DateTime.Now;
                await _repository.AddAsync(entity);
            }            
            return _mapper.Map<PersonDTO>(entity);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity =await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            _repository.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<PersonDTO>> GetListAsync()
        {
            return _mapper.Map<List<PersonDTO>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<ReportDataDTO>> GetReportDataAsync()
        {
            return _mapper.Map<List<ReportDataDTO>>(await _repository.GetReportData());
        }
    }
}
