using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
