using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HoMinhTienFinal.Models;
using HoMinhTienFinal.Models.Request;
using HoMinhTienFinal.Models.Respone;
using HoMinhTienFinal.Models.Ultis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HoMinhTienFinal.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly Context _context;
        public MembersController(Context context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseRespone>> Login(LoginRequest request)
        {
            if (!String.IsNullOrEmpty(request.username) && !String.IsNullOrEmpty(request.password))
            {
                var user = await _context.Members.Where(x => x.ACCOUNT == request.username && x.PASSWORD == request.password).AsNoTracking().FirstOrDefaultAsync();
                if (user != null)
                {
                    //generate token
                    var clainmData = new[] { new Claim(ClaimTypes.Name, request.username) };
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
                            UserID = user.MEM_ID,
                            username = user.FULLNAME,
                            token = "Bearer " + tokenString,
                        },
                    };
                }
            }
            else
            {
                return new BaseRespone
                {
                    ErrorCode = 1,
                    Message = "wrong user name or password",
                };
            }
            return new BaseRespone
            {
                ErrorCode = 2,
                Message = "wrong user name or password",
            };
        }

    }
}