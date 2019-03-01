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
    public class HoaDonController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public HoaDonController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/HoaDons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDons()
        {
            //return await _context.HoaDons.Include(x => x.NhanVien).Include(x => x.KhachHang).ToListAsync();
            return await _context.HoaDons.Select(x => new HoaDon
            {
                Id = x.Id,
                ngaydat = x.ngaydat,
                trangthai = x.trangthai,
                ghichu = x.ghichu,
                id_nhanvien = x.id_nhanvien,
                id_ban = x.id_ban,
                id_khachhang = x.id_khachhang,
                NhanVien = x.NhanVien,
                KhachHang=x.KhachHang,
                Ban = x.Ban,
                tongtien = _context.ChiTietDatBans.Where(t => t.id_hoadon == x.Id).Sum(t => t.soluong * t.dongia),
            }).ToListAsync();
        }

        // GET: api/HoaDons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDon(int id)
        {
            var hoaDon = await _context.HoaDons.Where(x => x.Id == id).Include(x => x.KhachHang).Include(x => x.NhanVien).FirstOrDefaultAsync();

            if (hoaDon == null)
            {
                return new HoaDon { Id = 0 };
            }
            
            return hoaDon;
        }

        // GET: tổng tiền
        [HttpGet("tongtien/{idHD}")]
        public async Task<ActionResult<double>> GetTongtien(int idHD)
        {
            var hoaDon = await _context.HoaDons.FindAsync(idHD);
            return _context.ChiTietDatBans.Where(t => t.id_hoadon == idHD).Sum(t => t.soluong * t.dongia);
        }

        // PUT: api/HoaDons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDon(int id, HoaDon hoaDon)
        {
            var hd = await _context.HoaDons.FindAsync(id);
            if (hd == null)
                return NotFound();
            hd.ghichu = hoaDon.ghichu;
            hd.id_nhanvien = hoaDon.id_nhanvien;
            hd.trangthai = hoaDon.trangthai;
            _context.HoaDons.Update(hd);
            await _context.SaveChangesAsync();
            return Ok(hd);
        }

        // POST: api/HoaDons
        [HttpPost]
        public async Task<ActionResult<HoaDon>> PostHoaDon(HoaDon hoaDon)
        {
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoaDon", new { id = hoaDon.Id }, hoaDon);
        }

        // DELETE: api/HoaDons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HoaDon>> DeleteHoaDon(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();

            return hoaDon;
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.Id == id);
        }
    }
}
