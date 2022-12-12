using PhoneApplications.Services.Report.Core.Entities;
using PhoneApplications.Services.Report.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Data.Repositories
{
    public class ReportRepository : GenericRepository<Reports>, IReportRepository
    {
        public ReportRepository(ReportContext dbContext) : base(dbContext)
        {
        }
    }
}
