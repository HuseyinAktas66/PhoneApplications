using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Core.DTOs
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; } = "";
    }
}
