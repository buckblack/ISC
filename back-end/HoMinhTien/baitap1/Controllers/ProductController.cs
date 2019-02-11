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
    public class ProductController : ControllerBase
    {
        private readonly DB _db;
        public ProductController(DB db)
        {
            _db = db;
        }

        //get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _db.Products.ToListAsync();
        }

        //get one
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(long id)
        {
            var product_item = await _db.Products.FindAsync(id);
            if (product_item == null)
                return NotFound();
            return product_item;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Product product_item)
        {
            _db.Products.Add(product_item);
            await _db.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = product_item.Id, }, product_item);
        }

        //update one
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(long id, Product product_item)
        {
            var item = await _db.Products.FindAsync(id);
            if (item == null)
                return NotFound();
            item.ProductID = product_item.ProductID;
            item.Name = product_item.Name;
            _db.Update(item);
            await _db.SaveChangesAsync();
            return Ok(item);
          
        }

        //delete one
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(long id)
        {
            var item = await _db.Products.FindAsync(id);
            if (item == null)
                return NotFound();
            _db.Products.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }

        //search name
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] string q)
        {
            return await _db.Products.Where(t => t.Name.Contains(q)).ToArrayAsync();
        }


    }
}