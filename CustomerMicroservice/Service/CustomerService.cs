using AutoMapper;
using CustomerMicroservice.DTO;
using CustomerMicroservice.Service.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly PreferenceService _preferenceService;
        private readonly IMapper _mapper;
        public CustomerService(CustomerRepository customerRepository, IMapper mapper, PreferenceService preferenceService)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _preferenceService = preferenceService;
        }

        public async Task<Customer> CreateCustomer(CustomerDTO CustomerDTO)
        {
            List<Preference> updatedPreferences = new List<Preference>();
            Customer customer = _mapper.Map<CustomerDTO, Customer>(CustomerDTO);
            if (customer.Preferences != null && customer.Preferences.Any())
            {
                foreach (var preferenceCompare in customer.Preferences)
                {
                    var preference = await _preferenceService.GetPreferenceByName(preferenceCompare.PreferenceName);

                    if (!customer.Preferences.Any(p => p.Id == preference.Id))
                    {
                        updatedPreferences.Add(preference);
                    }
                }
            }
            customer.Preferences = updatedPreferences;
            return await _customerRepository.AddCustomer(customer);
        }

        public Task<List<Preference>> GetPreferences(int customerId)
        {
            return _customerRepository.GetPreferences(customerId);
        }
    }
        
   }

