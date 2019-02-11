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
    public class ReceiptController : ControllerBase
    {
        private readonly DB _db;
        public ReceiptController(DB db)
        {
            _db = db;
        }

        //get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> Get()
        {
            return await _db.Receipts.Include(x=>x.Customer).ToListAsync();
        }

        //get one
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> Get(long id)
        {
            var receipt_item = await _db.Receipts.FindAsync(id);
            if (receipt_item == null)
                return NotFound();
            return receipt_item;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Receipt>> Post(Receipt receipt_item)
        {
            _db.Receipts.Add(receipt_item);
            await _db.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = receipt_item.Id, }, receipt_item);
        }

        //update one
        [HttpPut("{id}")]
        public async Task<ActionResult<Receipt>> Put(long id, Receipt receipt_item)
        {
            var item = await _db.Receipts.FindAsync(id);
            if (item == null)
                return NotFound();
            item.Customer_ID = receipt_item.Customer_ID;
            item.ReceiptDate = receipt_item.ReceiptDate;
            _db.Update(item);
            await _db.SaveChangesAsync();
            return Ok(item);

        }

        //delete one
        public async Task<ActionResult<Receipt>> Delete(long id)
        {
            var item = await _db.Receipts.FindAsync(id);
            if (item == null)
                return NotFound();
            _db.Receipts.Remove(item);
            await _db.SaveChangesAsync();
            return item;
        }
    }
}