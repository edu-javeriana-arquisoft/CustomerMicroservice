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

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly PreferenceService _preferenceService;

        public CustomersController(CustomerService _customerService)
        {
            _customerService = _customerService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerDTO customer)
        {

            var preferenceList = customer.preferences;
            List<Preference> realPreferences = new List<Preference>();
            foreach (String pref in preferenceList)
            {
                var realPreference = _preferenceService.GetPreferenceByName(pref);
                realPreferences.Add(await realPreference);
            }
            var newCustomer = await _customerService.CreateCustomer(customer,realPreferences);
            return CreatedAtAction("GetCustomer", new { id = newCustomer.Id }, newCustomer);
        }



    }
}
