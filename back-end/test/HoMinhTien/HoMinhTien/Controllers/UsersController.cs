using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoMinhTien.Models;
using HoMinhTien.Models.Request;
using HoMinhTien.Models.Utils;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using HoMinhTien.Models.Respone;

namespace HoMinhTien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseRespone>> Login(LoginRequest request)
        {
            if (!String.IsNullOrEmpty(request.UserName) && !String.IsNullOrEmpty(request.PassWord))
            {
                var user = await _context.Users.Where(x => x.UserName == request.UserName && x.Password == Helper.GenHash(request.PassWord)).AsNoTracking().FirstOrDefaultAsync();
                if (user != null)
                {
                    //generate token
                    var clainmData = new[] { new Claim(ClaimTypes.Name, request.UserName) };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Helper.AppKey));
                    var singingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: Helper.issuer,
                        audience: Helper.issuer,
                        expires: DateTime.Now.AddMinutes(30),
                        claims: clainmData,
                        signingCredentials: singingCredential
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return new BaseRespone
                    {
                        Data = new LoginRespone
                        {
                            UserID = user.UserId,
                            UserName = user.FullName,
                            Token = "Bearer " + tokenString,
                        },
                    };
                }
            }
            else
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Chưa nhập thông tin",
                };
            }
            return new BaseRespone
            {
                ErrorCode = 2,
                Message = "Sai tên đăng nhập hoặc mật khẩu",
            };
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
