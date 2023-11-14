using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Data;
using CustomerMicroservice.Models;
using CustomerMicroservice.Service;
using CustomerMicroservice.Service.Interfaces;
using CustomerMicroservice.DTO;
using AutoMapper;

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CustomerDTO customer)
        {
            if (customer == null)
            {
                return BadRequest("CustomerDTO cannot be null.");
            }

            Customer createdCustomer = await _customerService.CreateCustomer(customer);

            return CreatedAtAction(nameof(CreateCustomer), new { id = customer.Id }, createdCustomer);
        }



    }
}
