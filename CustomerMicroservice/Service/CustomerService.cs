using AutoMapper;
using CustomerMicroservice.DTO;
using CustomerMicroservice.Service.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

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

        public async Task<Customer> CreateCustomer(CustomerDTO CustomerDTO)
        {
            Customer customer = _mapper.Map<CustomerDTO, Customer>(CustomerDTO);
            await _customerRepository.AddCustomer(customer);
            return customer;
        }
      
    }
        
   }

