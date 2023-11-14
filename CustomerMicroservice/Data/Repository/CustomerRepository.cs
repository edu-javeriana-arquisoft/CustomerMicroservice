using CustomerMicroservice.Data.Interface;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
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

        public async Task<Customer> AddCustomer(Customer customer)
        {
            

            await _customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
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
