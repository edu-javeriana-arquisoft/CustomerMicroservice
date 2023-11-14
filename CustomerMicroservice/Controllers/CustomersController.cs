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
using MySql.Data.MySqlClient;

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
            try
            {
                if (customer == null)
                {
                    return BadRequest("CustomerDTO cannot be null.");
                }

                Customer createdCustomer = await _customerService.CreateCustomer(customer);
                if (createdCustomer == null)
                {
                    return BadRequest("Preference must exist");
                }
                return CreatedAtAction(nameof(CreateCustomer), new { id = customer.Id }, createdCustomer);
            }
            catch (DbUpdateException ex) when (ex.InnerException is MySqlException mysqlException && mysqlException.Number == 1062)
            {
                return Conflict("El correo electrónico ya está en uso.");
            }
            
        }

        [HttpGet("GetPreferences/{customerId}")]
        public async Task<ActionResult<List<Preference>>> GetPreferences(int customerId)
        {
            try
            {
                var preferences = await _customerService.GetPreferences(customerId);
                if (preferences == null || preferences.Count == 0)
                {
                    return NotFound("No se encontraron preferencias para el cliente.");
                }

                return Ok(preferences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
