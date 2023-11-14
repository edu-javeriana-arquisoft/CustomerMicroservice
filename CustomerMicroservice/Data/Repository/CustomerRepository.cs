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

        public async Task<List<Preference>> GetPreferences(int customerId)
        {

            var customer = await _customers.FindAsync(customerId);

            if (customer != null)
            {
                await _context.Entry(customer)
                              .Collection(c => c.Preferences)
                              .LoadAsync();

                return customer.Preferences.ToList();
            }

            return null;
        }

        Task<Customer> ICustomerRepository.AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
