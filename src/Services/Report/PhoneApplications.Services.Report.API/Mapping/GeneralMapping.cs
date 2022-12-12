using AutoMapper;
using PhoneApplications.Services.Report.Core.DTOs;
using PhoneApplications.Services.Report.Core.Entities;

namespace PhoneApplications.Services.Report.API.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Reports, ReportDTO>().ReverseMap();

        }
    }
}
