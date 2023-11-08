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
                .HasMany(c => c.CustomerPreference)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.Id)
                .IsRequired();
        }
        public  DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPreference> CustomerPreferences { get; set; }
    }
}
