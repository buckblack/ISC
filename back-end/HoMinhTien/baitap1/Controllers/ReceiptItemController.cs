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
    public class ReceiptItemController : ControllerBase
    {
        private readonly DB _db;
        public ReceiptItemController(DB db)
        {
            _db = db;
        }

        //get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt_Item>>> Get()
        {
            return await _db.Receipt_Items.Include(x=>x.Product).Include(x=>x.Receipt).ToListAsync();
        }

        //get one
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt_Item>> Get(long id)
        {
            var receipt_item = await _db.Receipt_Items.FindAsync(id);
            if (receipt_item == null)
                return NotFound();
            return receipt_item;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Receipt_Item>> Post(Receipt_Item receipt_item)
        {
            _db.Receipt_Items.Add(receipt_item);
            await _db.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = receipt_item.Id, }, receipt_item);
        }

        //update one
        [HttpPut("{id}")]
        public async Task<ActionResult<Receipt_Item>> Put(long id, Receipt_Item receipt_item)
        {
            var item = await _db.Receipt_Items.FindAsync(id);
            if (item == null)
                return NotFound();
            item.Product_ID = receipt_item.Product_ID;
            item.Receipt_ID = receipt_item.Receipt_ID;
            item.Quantity = receipt_item.Quantity;
            item.Price = receipt_item.Price;
            _db.Update(item);
            await _db.SaveChangesAsync();
            return Ok(item);

        }

        //delete one
        public async Task<ActionResult<Receipt_Item>> Delete(long id)
        {
            var item = await _db.Receipt_Items.FindAsync(id);
            if (item == null)
                return NotFound();
            _db.Receipt_Items.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }
    }
}