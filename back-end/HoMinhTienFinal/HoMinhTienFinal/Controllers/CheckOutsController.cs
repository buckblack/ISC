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
    [Route("api/checkout")]
    [ApiController]
    public class CheckOutsController : ControllerBase
    {
        private readonly Context _context;

        public CheckOutsController(Context context)
        {
            _context = context;
        }

        [HttpGet("search/{q}")]
        public async Task<ActionResult<IEnumerable<SearcCheckOutRespone>>> Search(string q)
        {
            return await _context.CheckOuts.Where(x => x.Librarian.FULLNAME.Contains(q) || x.Member.FULLNAME.Contains(q))
                .Select(x => new SearcCheckOutRespone
                {
                    CheckOutID = x.CHK_ID,
                    CreateDate = x.CREATEDDATE,
                    MemberName = x.Member.FULLNAME,
                    LibrarianName = x.Librarian.FULLNAME,
                    Book_borrowed = _context.CheckOutDetails.Where(t => t.CHK_ID == x.CHK_ID).Count(),
                }).ToListAsync();
        }
    }
}
