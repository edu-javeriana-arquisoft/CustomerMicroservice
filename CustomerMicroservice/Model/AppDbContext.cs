using Microsoft.EntityFrameworkCore;
namespace CustomerMicroservice.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=10.43.100.43;database=Business;uid=root;pwd=root");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPreference>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerPreference)
                .HasForeignKey(cp => cp.Id)
                .IsRequired();
        }

    }
}
