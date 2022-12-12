using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.DTOs
{
    public class ContactDTO:BaseDTO
    {        
        public Guid PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Information { get; set; } = "";
    }
}
