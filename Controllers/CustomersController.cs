using BankSolution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _customerContext;

        public CustomersController(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        //Get : api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_customerContext.Customers == null) 
            {
                return NotFound();
            }
            return await _customerContext.Customers.ToListAsync();

        }

        //Get : api/Customers/2
        [HttpGet("{id}")]

        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_customerContext.Customers is null)
            {
                return NotFound();
            }
            var customer = await _customerContext.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return customer;
        }


        // Post : api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _customerContext.Customers.Add(customer);
            await _customerContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // Put : api/Customers/2
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            _customerContext.Entry(customer).State = EntityState.Modified;
            try
            {
                await _customerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return (_customerContext.Customers?.Any(customer => customer.Id == id)).GetValueOrDefault();
        }

        // Delete : api/Customers/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            if (_customerContext.Customers is null)
            {
                return NotFound();
            }
            var customer = await _customerContext.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            _customerContext.Customers.Remove(customer);
            await _customerContext.SaveChangesAsync();
            return NoContent();
        }


    }
}

