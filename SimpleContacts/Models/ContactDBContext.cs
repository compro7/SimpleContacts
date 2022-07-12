using Microsoft.EntityFrameworkCore;

namespace SimpleContacts.Models
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions<ContactDBContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}
