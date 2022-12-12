using Microsoft.EntityFrameworkCore;
using PhoneApplications.Services.Report.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Data
{
    public class ReportContext:DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options) { }
        public DbSet<Reports> Reports { get; set; }

    }
}
