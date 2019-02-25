using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codefirst.Models;
using codefirst.Models.respone;
using Microsoft.AspNetCore.Authorization;

namespace codefirst.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly Db _context;

        public MajorsController(Db context)
        {
            _context = context;
        }

        // GET: api/Majors
        [HttpGet]
        public async Task<ActionResult<BaseRespone>> GetMajors()
        {
            var major= await _context.Majors.AsNoTracking().ToListAsync();
            return new BaseRespone(major);
        }

        // GET: api/Majors/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRespone>> GetMajor(int id)
        {
            var major = await _context.Majors.FindAsync(id);

            if (major != null)
            {
                return new BaseRespone (major);
            }
            else
            {
                return new BaseRespone
                {
                    ErrorCode = 404,
                    Message = "Không tìm thấy"
                };
            }

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
            _context.Majors.Add(major);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMajor", new { id = major.MajorID }, major);
        }

        // DELETE: api/Majors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Major>> DeleteMajor(int id)
        {
            var major = await _context.Majors.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            _context.Majors.Remove(major);
            await _context.SaveChangesAsync();

            return major;
        }

        private bool MajorExists(int id)
        {
            return _context.Majors.Any(e => e.MajorID == id);
        }
    }
}
