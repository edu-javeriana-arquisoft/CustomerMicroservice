using System.Data;

namespace CustomerMicroservice.Data.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> GetCustomer(int customerId);
        Task<List<Preference>> GetPreferences(int customerId);
    }
}
