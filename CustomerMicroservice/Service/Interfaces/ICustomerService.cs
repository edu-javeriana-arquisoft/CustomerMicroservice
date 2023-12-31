﻿using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerMicroservice.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(CustomerDTO CustomerDTO);
        Task<List<Preference>> GetPreferences(int customerId);
    }
}
