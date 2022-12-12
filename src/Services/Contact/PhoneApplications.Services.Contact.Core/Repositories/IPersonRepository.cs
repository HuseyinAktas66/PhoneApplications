using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.Repositories
{
    public interface IPersonRepository:IGenericRepository<Persons>
    {
        Task<IEnumerable<ReportDataDTO>> GetReportData();
    }
}
