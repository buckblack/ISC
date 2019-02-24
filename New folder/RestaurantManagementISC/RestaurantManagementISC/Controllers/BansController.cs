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
    public class BansController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public BansController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/Bans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ban>>> GetBans()
        {
            return await _context.Bans.ToListAsync();
        }

        // GET: api/Bans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ban>> GetBan(int id)
        {
            var ban = await _context.Bans.FindAsync(id);

            if (ban == null)
            {
                return NotFound();
            }

            return ban;
        }

        // GET: lấy hóa đơn của bàn
        [HttpGet("hoadon/{idban}")]
        public async Task<ActionResult<int>> GetHoaDon(int idban)
        {
            var ban = await _context.Bans.FindAsync(idban);

            if (ban.hoadonphucvu == null)
            {
                return _context.HoaDons.Max(x => x.Id) + 1;
            }

            return ban.hoadonphucvu;
        }

        // PUT: api/Bans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBan(Ban ban, int id)
        {
            var b = await _context.Bans.FindAsync(id);
            if (b == null)
                return NotFound();
            b.trangthai = ban.trangthai;
            b.hoadonphucvu = ban.hoadonphucvu;
            _context.Bans.Update(b);
            await _context.SaveChangesAsync();
            return Ok(b);
        }

        // POST: api/Bans
        [HttpPost]
        public async Task<ActionResult<Ban>> PostBan(Ban ban)
        {
            _context.Bans.Add(ban);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBan", new { id = ban.Id }, ban);
        }

        // DELETE: api/Bans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ban>> DeleteBan(int id)
        {
            var ban = await _context.Bans.FindAsync(id);
            if (ban == null)
            {
                return NotFound();
            }

            _context.Bans.Remove(ban);
            await _context.SaveChangesAsync();

            return ban;
        }

        private bool BanExists(int id)
        {
            return _context.Bans.Any(e => e.Id == id);
        }
    }
}
