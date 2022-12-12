using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Core.Entities
{
    public class Reports : BaseEntity
    {
        public DateTime RequestedDate { get; set; }
        [MaxLength(50)]
        public string Status { get; set; } = "";
        [MaxLength(300)]
        public string FilePath { get; set; } = "";
    }
}
