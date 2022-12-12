using PhoneApplications.Services.Report.Core.DTOs;
using PhoneApplications.Services.Report.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Core.Services
{
    public interface IReportService:IBaseService<Reports>
    {
        Task<IEnumerable<ReportDTO>> GetListAsync();

        Task<ReportDTO> AddAsync();

        Task<bool> CompleteReport(Guid id, string filepath);

        Task<string> GetReportData(Guid id);
    }
}
