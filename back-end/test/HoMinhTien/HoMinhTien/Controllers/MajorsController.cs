using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoMinhTien.Models;
using Microsoft.AspNetCore.Authorization;
using HoMinhTien.Models.Respone;

namespace HoMinhTien.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly Context _context;

        public MajorsController(Context context)
        {
            _context = context;
        }

        // GET: api/Majors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Major>>> GetMajor()
        {
            return await _context.Major.ToListAsync();
        }

        // GET: api/Majors/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Major>> GetMajor(int id)
        {
            var major = await _context.Major.FindAsync(id);

            if (major == null)
            {
                return NotFound();
            }

            return major;
        }

        // PUT: api/Majors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajor(int id, Major major)
        {
            if (id != major.MajorID)
            {
                return BadRequest();
            }

            _context.Entry(major).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
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

        // POST: api/Majors
        [HttpPost]
        public async Task<ActionResult<Major>> PostMajor(Major major)
        {
            _context.Major.Add(major);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMajor", new { id = major.MajorID }, major);
        }

        // DELETE: api/Majors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Major>> DeleteMajor(int id)
        {
            var major = await _context.Major.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            _context.Major.Remove(major);
            await _context.SaveChangesAsync();

            return major;
        }

        private bool MajorExists(int id)
        {
            return _context.Major.Any(e => e.MajorID == id);
        }
    }
}
