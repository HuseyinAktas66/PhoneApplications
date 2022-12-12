using Microsoft.EntityFrameworkCore;
using PhoneApplications.Services.Contact.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Contact.Data
{
    public class PersonContext:DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

        public DbSet<Persons> Persons { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<ContactTypes> ContactTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactTypes>().HasData(
                new ContactTypes {Id=1, Description="Telefon Numarası" },
                new ContactTypes {Id=2, Description="E-mail Adresi" },
                new ContactTypes { Id = 3, Description = "Konum" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
