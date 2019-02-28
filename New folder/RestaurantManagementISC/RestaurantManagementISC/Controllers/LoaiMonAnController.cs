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
    public class LoaiMonAnController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public LoaiMonAnController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/LoaiMonAns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiMonAn>>> GetLoaiMonAns()
        {
            return await _context.LoaiMonAns.ToListAsync();
        }

        // GET: api/LoaiMonAns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiMonAn>> GetLoaiMonAn(int id)
        {
            var loaiMonAn = await _context.LoaiMonAns.FindAsync(id);

            if (loaiMonAn == null)
            {
                return NotFound();
            }

            return loaiMonAn;
        }

        // PUT: api/LoaiMonAns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiMonAn(int id, LoaiMonAn loaiMonAn)
        {
            if (id != loaiMonAn.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaiMonAn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiMonAnExists(id))
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

        // POST: api/LoaiMonAns
        [HttpPost]
        public async Task<ActionResult<LoaiMonAn>> PostLoaiMonAn(LoaiMonAn loaiMonAn)
        {
            _context.LoaiMonAns.Add(loaiMonAn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiMonAn", new { id = loaiMonAn.Id }, loaiMonAn);
        }

        // DELETE: api/LoaiMonAns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiMonAn>> DeleteLoaiMonAn(int id)
        {
            var loaiMonAn = await _context.LoaiMonAns.FindAsync(id);
            if (loaiMonAn == null)
            {
                return NotFound();
            }

            _context.LoaiMonAns.Remove(loaiMonAn);
            await _context.SaveChangesAsync();

            return loaiMonAn;
        }

        private bool LoaiMonAnExists(int id)
        {
            return _context.LoaiMonAns.Any(e => e.Id == id);
        }
    }
}
