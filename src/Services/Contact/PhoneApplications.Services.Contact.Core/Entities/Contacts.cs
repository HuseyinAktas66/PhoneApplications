using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.Entities
{
    public class Contacts: BaseEntity
    {
        public Guid PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Information { get; set; }
        public virtual Persons Person { get; set; }
        public virtual ContactTypes ContactType { get; set; }
    }
}
