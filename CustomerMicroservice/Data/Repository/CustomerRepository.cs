using CustomerMicroservice.Data.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerMicroservice.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Customer> _customers;
        public CustomerRepository(ApplicationDbContext context) {
            _context = context;
            _customers = context.Customers;
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public Task<Customer> GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        Task<Customer> ICustomerRepository.AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
