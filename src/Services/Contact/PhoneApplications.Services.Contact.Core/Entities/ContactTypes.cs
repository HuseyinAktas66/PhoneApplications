using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.Entities
{
    public class ContactTypes
    {
        public int Id { get; set; }=0;
        [MaxLength(50)]
        public string Description { get; set; } = "";
        
    }
}
