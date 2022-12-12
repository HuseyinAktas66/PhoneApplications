using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.Entities
{
    public class Contacts: BaseEntity
    {
        public Contacts()
        {
            //Person = new Persons();
            //ContactType = new ContactTypes();
        }        
        
        [MaxLength(50)]
        public string Information { get; set; } = "";
        public virtual Guid PersonId { get; set; }
        public virtual Persons Person { get; set; }
        public virtual int ContactTypeId { get; set; }
        public virtual ContactTypes ContactType { get; set; }
    }
}
