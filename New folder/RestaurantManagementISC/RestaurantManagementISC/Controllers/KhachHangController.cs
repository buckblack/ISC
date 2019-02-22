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
    public class KhachHangController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public KhachHangController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/KhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetKhachHangs()
        {
            return await _context.KhachHangs.ToListAsync();
        }

        // GET: api/KhachHang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(int id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);

            if (khachHang == null)
            {
                return NotFound();
            }

            return khachHang;
        }

        // PUT: api/KhachHang/5
        [HttpPut("{id}")]
        public async Task<ActionResult<KhachHang>> Put(int id, KhachHang khachhang)
        {
            var kh = await _context.KhachHangs.FindAsync(id);
            if (kh == null)
            {
                return NotFound();
            }
          
            kh.hokhachhang = khachhang.hokhachhang;
            kh.tenkhachhang = khachhang.tenkhachhang;
            kh.email = khachhang.email;
            kh.diachi = khachhang.diachi;
            kh.dienthoai = khachhang.dienthoai;
            kh.ghichu = khachhang.ghichu;

            _context.KhachHangs.Update(kh);
            await _context.SaveChangesAsync();
            return Ok(kh);
        }

        // POST: api/KhachHang
        [HttpPost]
        public async Task<ActionResult<KhachHang>> PostKhachHang(KhachHang khachHang)
        {
            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhachHang", new { id = khachHang.Id }, khachHang);
        }

        // DELETE: api/KhachHang/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KhachHang>> DeleteKhachHang(int id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();

            return khachHang;
        }

        private bool KhachHangExists(int id)
        {
            return _context.KhachHangs.Any(e => e.Id == id);
        }
    }
}
