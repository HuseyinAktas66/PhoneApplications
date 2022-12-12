using AutoMapper;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.DTOs.CreateDTOs;
using PhoneApplications.Services.Contact.Core.Entities;

namespace PhoneApplications.Services.Contact.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Persons, PersonDTO>().ReverseMap();
            CreateMap<Persons, CreatePersonDTO>().ReverseMap();
            CreateMap<Contacts, ContactDTO>().ReverseMap();
            CreateMap<Contacts, CreateContactDTO>().ReverseMap();

        }
    }
}
