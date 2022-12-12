using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Data
{
    public class CAPDbContext:DbContext
    {
        public CAPDbContext(DbContextOptions<CAPDbContext> options) : base(options) { }
    }
}
