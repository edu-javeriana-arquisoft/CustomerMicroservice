using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Data;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPreferencesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerPreferencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerPreferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerPreference>>> GetCustomerPreferences()
        {
          if (_context.CustomerPreferences == null)
          {
              return NotFound();
          }
            return await _context.CustomerPreferences.ToListAsync();
        }

        // GET: api/CustomerPreferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerPreference>> GetCustomerPreference(int id)
        {
          if (_context.CustomerPreferences == null)
          {
              return NotFound();
          }
            var customerPreference = await _context.CustomerPreferences.FindAsync(id);

            if (customerPreference == null)
            {
                return NotFound();
            }

            return customerPreference;
        }

        // PUT: api/CustomerPreferences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerPreference(int id, CustomerPreference customerPreference)
        {
            if (id != customerPreference.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerPreference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerPreferenceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerPreferences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerPreference>> PostCustomerPreference(CustomerPreference customerPreference)
        {
          if (_context.CustomerPreferences == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CustomerPreferences'  is null.");
          }
            _context.CustomerPreferences.Add(customerPreference);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerPreferenceExists(customerPreference.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerPreference", new { id = customerPreference.Id }, customerPreference);
        }

        // DELETE: api/CustomerPreferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerPreference(int id)
        {
            if (_context.CustomerPreferences == null)
            {
                return NotFound();
            }
            var customerPreference = await _context.CustomerPreferences.FindAsync(id);
            if (customerPreference == null)
            {
                return NotFound();
            }

            _context.CustomerPreferences.Remove(customerPreference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerPreferenceExists(int id)
        {
            return (_context.CustomerPreferences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
