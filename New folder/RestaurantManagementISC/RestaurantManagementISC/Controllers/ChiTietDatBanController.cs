using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementISC.Models;
using RestaurantManagementISC.Models.VewModels;

namespace RestaurantManagementISC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDatBanController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public ChiTietDatBanController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietDatBan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDatBan>>> GetChiTietDatBans()
        {
            return await _context.ChiTietDatBans.Include(x => x.MonAn).Include(x => x.HoaDon).ToListAsync();
        }

        //kiểm tra đã gọi món đó chưa
        [HttpPost("kiemtra")]
        public async Task<ActionResult<bool>> GetKiemtraMonan(ChitietRequest chitiet)
        {
            var check= _context.ChiTietDatBans.Where(x => x.id_hoadon == chitiet.idHoaDon && x.id_monan == chitiet.idMonAn).FirstOrDefault();
            if (check == null)
                return true;
            return false;
        }

        [HttpGet("HoaDon/{idHoaDon}")]
        public async Task<ActionResult<IEnumerable<ChiTietDatBan>>> Get(int idHoaDon)
        {
            return await _context.ChiTietDatBans.Where(x => x.id_hoadon.Equals(idHoaDon)).Include(x => x.MonAn).Include(x => x.HoaDon).ToListAsync();
        }

        // GET: api/ChiTietDatBan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDatBan>> GetChiTietDatBan(int id)
        {
            var chiTietDatBan = await _context.ChiTietDatBans.FindAsync(id);

            if (chiTietDatBan == null)
            {
                return NotFound();
            }

            return chiTietDatBan;
        }

        // PUT: api/ChiTietDatBan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDatBan(int id, ChiTietDatBan chiTietDatBan)
        {
            var ct = await _context.ChiTietDatBans.FindAsync(id);
            if (ct == null)
                return NotFound();
            ct.soluong = chiTietDatBan.soluong;
            _context.ChiTietDatBans.Update(ct);
            await _context.SaveChangesAsync();
            return Ok(ct);
        }

        // POST: api/ChiTietDatBan
        [HttpPost]
        public async Task<ActionResult<ChiTietDatBan>> PostChiTietDatBan(ChiTietDatBan chiTietDatBan)
        {
            _context.ChiTietDatBans.Add(chiTietDatBan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietDatBan", new { id = chiTietDatBan.Id }, chiTietDatBan);
        }

        // DELETE: api/ChiTietDatBan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChiTietDatBan>> DeleteChiTietDatBan(int id)
        {
            var chiTietDatBan = await _context.ChiTietDatBans.FindAsync(id);
            if (chiTietDatBan == null)
            {
                return NotFound();
            }

            _context.ChiTietDatBans.Remove(chiTietDatBan);
            await _context.SaveChangesAsync();

            return chiTietDatBan;
        }

        private bool ChiTietDatBanExists(int id)
        {
            return _context.ChiTietDatBans.Any(e => e.Id == id);
        }
    }
}
