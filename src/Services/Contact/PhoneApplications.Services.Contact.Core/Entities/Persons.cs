using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(50)]
        public string Surname { get; set; } = "";
        [MaxLength(100)]
        public string Company { get; set; } = "";    
        public virtual ICollection<Contacts> Contacts { get; set; }        
    }
}
