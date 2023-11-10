using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace CustomerMicroservice.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Preferences)
                .WithMany(e => e.Customers);
        }
        public  DbSet<Customer> Customers { get; set; }
        public DbSet<Preference> Preferences { get; set; }

    }
}
