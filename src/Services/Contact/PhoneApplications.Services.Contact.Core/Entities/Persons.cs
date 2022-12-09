using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Core.Entities
{
    public class Persons:BaseEntity
    {
        public Persons()
        {
            Contacts = new Collection<Contacts>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }        
        public virtual ICollection<Contacts> Contacts { get; set; }        
    }
}
