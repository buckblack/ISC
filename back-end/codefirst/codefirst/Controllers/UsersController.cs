using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codefirst.Models;
using codefirst.Models.utits;
using codefirst.Models.request;
using codefirst.Models.respone;

namespace codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Db _context;

        

        public UsersController(Db context)
        {
            _context = context;
            if(_context.Users.ToList().Count()==0)
            {
                User newUser = new User {
                    UserName = "admin",
                    Password=Helper.GenHash("123456"),
                    FullName="Tiến",
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5

        // POST: api/Users
        [HttpPost("login")]
        public async Task<ActionResult<BaseRespone>> Login(LoginResquest resquest)
        {
            if(!String.IsNullOrEmpty(resquest.UserName) && !String.IsNullOrEmpty(resquest.PassWord))
            {
                var user = await _context.Users.Where(x => x.UserName == resquest.UserName && x.Password == Helper.GenHash(resquest.PassWord)).AsNoTracking().FirstOrDefaultAsync();
                if(user!=null)
                {
                    return new BaseRespone
                    {
                        Data = new LoginRespone {
                            UserID = user.UserId,
                            UserName = user.FullName,
                            Token = "",
                        },
                    };
                }
            }
            else
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "Sai tên đăng nhập hoặc mật khẩu",
                };
            }
            return new BaseRespone
            {
                ErrorCode = 2,
                Message = "",
            };
        }

        // DELETE: api/Users/5
       
    }
}
