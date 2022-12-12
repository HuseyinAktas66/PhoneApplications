using Microsoft.EntityFrameworkCore;
using PhoneApplications.Services.Contact.Core.Entities;
using PhoneApplications.Services.Contact.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Data.Repositories
{
    public class ContactRepository : GenericRepository<Contacts>, IContactRepository
    {
        private PersonContext _contactTypeContext { get => _dbContext as PersonContext; }
        public ContactRepository(PersonContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ContactTypes>> GetContactTypes()
        {
            return await _contactTypeContext.ContactTypes.ToListAsync();
        }
    }
}
