namespace CustomerMicroservice.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public  DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPreference> CustomerPreferences { get; set; }
    }
}
