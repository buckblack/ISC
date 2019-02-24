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
    public class NguyenLieuController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public NguyenLieuController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/NguyenLieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguyenLieu>>> GetNguyenLieus()
        {
            return await _context.NguyenLieus.ToListAsync();
        }

        // GET: api/NguyenLieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguyenLieu>> GetNguyenLieu(int id)
        {
            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);

            if (nguyenLieu == null)
            {
                return NotFound();
            }

            return nguyenLieu;
        }

        // PUT: api/NguyenLieu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguyenLieu(int id, NguyenLieu nguyenLieu)
        {
            if (id != nguyenLieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(nguyenLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguyenLieuExists(id))
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

        // POST: api/NguyenLieu
        [HttpPost]
        public async Task<ActionResult<NguyenLieu>> PostNguyenLieu(NguyenLieu nguyenLieu)
        {
            _context.NguyenLieus.Add(nguyenLieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguyenLieu", new { id = nguyenLieu.Id }, nguyenLieu);
        }

        //tìm
        [HttpGet("tim")]
        public async Task<ActionResult<IEnumerable<NguyenLieu>>> PostTimNguyenLieu([FromQuery] string q)
        {
            return await _context.NguyenLieus.Where(x => x.tennguyenlieu.Contains(q)).ToListAsync();
        }

        // DELETE: api/NguyenLieu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NguyenLieu>> DeleteNguyenLieu(int id)
        {
            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }

            _context.NguyenLieus.Remove(nguyenLieu);
            await _context.SaveChangesAsync();

            return nguyenLieu;
        }

        private bool NguyenLieuExists(int id)
        {
            return _context.NguyenLieus.Any(e => e.Id == id);
        }
    }
}
