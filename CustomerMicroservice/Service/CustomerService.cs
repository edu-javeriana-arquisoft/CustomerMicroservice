using AutoMapper;
using CustomerMicroservice.Service.Interfaces;

namespace CustomerMicroservice.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomer(CustomerDTO CustomerDTO, List<Preference> preferences)
        {
            var customer = _mapper.Map<Customer>(CustomerDTO);
            customer.Preferences = preferences;
            await _customerRepository.AddCustomer(customer);
            return customer;
        }
      
    }
        
   }

