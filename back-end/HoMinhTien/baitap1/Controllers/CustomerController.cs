using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baitap1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace baitap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DB _db;
        public CustomerController(DB db)
        {
            _db = db;
        }

        //get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await _db.Customers.ToListAsync();
        }

        //get one
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(long id)
        {
            var customer_item = await _db.Customers.FindAsync(id);
            if (customer_item == null)
                return NotFound();
            return customer_item;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer_item)
        {
            _db.Customers.Add(customer_item);
            await _db.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = customer_item.Id, }, customer_item);
        }

        //update one
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(long id,Customer customer_item)
        {
            var item = await _db.Customers.FindAsync(id);
            if (item == null)
                return NotFound();
            item.Name = customer_item.Name;
            item.Address = customer_item.Address;
            item.CustomerID = customer_item.CustomerID;
            _db.Customers.Update(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }

        //delete one
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(long id)
        {
            var item = await _db.Customers.FindAsync(id);
            if (item == null)
                return NotFound();
            _db.Customers.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }

        //search name
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Customer>>> Search([FromQuery] string q)
        {
            return await _db.Customers.Where(t => t.Name.Contains(q)).ToArrayAsync();
        }

    }
}