using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoMinhTienFinal.Models;
using HoMinhTienFinal.Models.Respone;
using Microsoft.AspNetCore.Authorization;

namespace HoMinhTienFinal.Controllers
{
    [Authorize]
    [Route("api/librarian")]
    [ApiController]
    public class LibrariansController : ControllerBase
    {
        private readonly Context _context;

        public LibrariansController(Context context)
        {
            _context = context;
        }

        // GET: api/Librarians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Librarian>>> GetLibrarians()
        {
            return await _context.Librarians.AsNoTracking().ToListAsync();
        }

        // GET: api/Librarians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Librarian>> GetLibrarian(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);

            if (librarian == null)
            {
                return NotFound();
            }

            return librarian;
        }

        // PUT: api/Librarians/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrarian(int id, Librarian librarian)
        {
            var lib = await _context.Librarians.FindAsync(id);
            if (lib == null)
                return NotFound();
            lib.FULLNAME = librarian.FULLNAME;
            lib.GENDER = librarian.GENDER;
            lib.PASSWORD = librarian.PASSWORD;
            lib.PHONE = librarian.PHONE;
            lib.EMAIL = librarian.EMAIL;
            _context.Librarians.Update(lib);
            await _context.SaveChangesAsync();
            return Ok(lib);
        }

        // POST: api/Librarians
        [HttpPost]
        public async Task<ActionResult<Librarian>> PostLibrarian(Librarian librarian)
        {
            _context.Librarians.Add(librarian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrarian", new { id = librarian.LIB_ID }, librarian);
        }

        // DELETE: api/Librarians/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseRespone>> DeleteLibrarian(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian == null)
            {
                return new BaseRespone { ErrorCode = 1, Message = "Delete Failed" };
            }

            _context.Librarians.Remove(librarian);
            await _context.SaveChangesAsync();

            return new BaseRespone { Message = "Delete Successed"};
        }

    }
}
