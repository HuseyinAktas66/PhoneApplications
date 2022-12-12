using Microsoft.EntityFrameworkCore;
using PhoneApplications.Services.Contact.Core.DTOs;
using PhoneApplications.Services.Contact.Core.Entities;
using PhoneApplications.Services.Contact.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Data.Repositories
{
    public class PersonRepository : GenericRepository<Persons>, IPersonRepository
    {
        private PersonContext _personContext { get => _dbContext as PersonContext; }
        public PersonRepository(PersonContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ReportDataDTO>> GetReportData()
        {
            var locations = await (from p in _personContext.Persons
                                  join pc in _personContext.Contacts on p.Id equals pc.PersonId
                                  where pc.ContactTypeId == 3
                                  group pc by pc.Information into list
                                  select new ReportDataDTO
                                  {
                                      Location = list.Key,
                                      PersonCount = list.Count(),
                                      PhoneCount = (from pc2 in _personContext.Contacts
                                                                join p2 in _personContext.Persons on pc2.PersonId equals p2.Id
                                                                where pc2.ContactTypeId == 1
                                                                    && (from pc3 in _personContext.Contacts where pc3.PersonId == p2.Id && pc3.Information == list.Key select pc3).Any()
                                                                select pc2).Count(),
                                  }).ToListAsync();
            return locations;
        }
    }
}
