using Entities.ModelConfiguration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Entities
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());

            var initial = new InitialData();
            modelBuilder.Entity<Contact>().HasData(initial.Contacts);
            modelBuilder.Entity<Account>().HasData(initial.Accounts);
            modelBuilder.Entity<Incident>().HasData(initial.Incidents);
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}