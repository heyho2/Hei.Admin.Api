using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hei.Admin.Api.Controllers
{
    [Route("api/[controller]/[action]"), Authorize]
    public class TokenController : BaseApiController
    {
        public IConfiguration Configuration { get; }
        public TokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 登录（签发token）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [AllowAnonymous, HttpPost]
        public JsonResult Login(string name, string pwd)
        {
            var claims = new[]
               {
                   new Claim(ClaimTypes.Role, "test"),
                   new Claim(ClaimTypes.MobilePhone, "157****7350"),
                   new Claim("userId","value")
               };
            var now = DateTime.UtcNow;
            double.TryParse(Configuration["Authentication:JwtBearer:Expiration"], out double expires);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Authentication:JwtBearer:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                   issuer: Configuration["Authentication:JwtBearer:Issuer"],
                   audience: Configuration["Authentication:JwtBearer:Audience"],
                   claims: claims,
                    expires: now.AddMinutes(expires),
                   notBefore: now,
                   signingCredentials: creds);
            return Json(new
            {
                Authorization = $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}"
            });
        }
    }
}
