using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementISC.Models;

namespace RestaurantManagementISC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonAnController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public MonAnController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/MonAn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonAn>>> GetMonAns()
        {
            return await _context.MonAns.Include(x=>x.LoaiMonAn).ToListAsync();
        }

        // GET: api/MonAn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonAn>> GetMonAn(int id)
        {
            var monAn = await _context.MonAns.Where(x=>x.Id==id).Include(x => x.LoaiMonAn).FirstOrDefaultAsync();

            if (monAn == null)
            {
                return NotFound();
            }

            return monAn;
        }

        //tìm
        [HttpGet("tim")]
        public async Task<ActionResult<IEnumerable<MonAn>>> GetTimNguyenLieu([FromQuery] string q)
        {
            return await _context.MonAns.Where(x => x.tenmonan.Contains(q)).ToListAsync();
        }

        // PUT: api/MonAn/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonAn(int id, MonAn monAn)
        {
            if (id != monAn.Id)
            {
                return BadRequest();
            }

            _context.Entry(monAn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonAnExists(id))
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

        // POST: api/MonAn
        [HttpPost]
        public async Task<ActionResult<MonAn>> PostMonAn(MonAn monAn)
        {
            _context.MonAns.Add(monAn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonAn", new { id = monAn.Id }, monAn);
        }

        // DELETE: api/MonAn/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MonAn>> DeleteMonAn(int id)
        {
            var monAn = await _context.MonAns.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }

            _context.MonAns.Remove(monAn);
            await _context.SaveChangesAsync();

            return monAn;
        }

        private bool MonAnExists(int id)
        {
            return _context.MonAns.Any(e => e.Id == id);
        }
    }
}
