using Hei.Admin.Core.Encrypt;
using Hei.Admin.Core.Redis;
using Hei.Admin.Core.Utils;
using Hei.Admin.Service;
using Hei.Admin.Service.Basic;
using Hei.Admin.ViewModel;
using Hei.Admin.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Api.Controllers
{
    [Route("api/[controller]/[action]"), Authorize]
    public class TokenController : BaseApiController
    {
        public IConfiguration Configuration { get; }
        public RedisStringService _redisString;
        public SysUserService _sysUserService;
        public TokenController(IConfiguration configuration, RedisStringService redisString, SysUserService sysUserService)
        {
            Configuration = configuration;
            _redisString = redisString;
            _sysUserService = sysUserService;
        }
        /// <summary>
        /// 登录（签发token）
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, HttpPost]
        public ApiActionResult<LoginResponse> Login([FromBody]LoginRequest request)
        {
            var claims = new[]
               {
                   new Claim(ClaimTypes.Role, "test"),
                   new Claim(ClaimTypes.Sid, "test"),
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
            return Success(new LoginResponse
            {
                Authorization = $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}"
            });
        }
        [AllowAnonymous, HttpPost,Produces(typeof(ApiActionResult<LoginResponse>))]
        public async Task<IActionResult> Login2([FromBody]LoginRequest request)
        {
            var user = await _sysUserService.FirstOrDefaultAsync(a => new
            {
                a.UserName,
                a.Id,
                a.RealName,
                a.Mobile,
                a.Password
            }, a => a.UserName == request.Name);
            if (user == null)
            {
                return Fail("找不到用户名");
            }
            var token = GetToken(user.Id, user.UserName);
            _redisString.Set(string.Format(RedisKey.LoginTokenKey, token), new UserInfo
            {
                Id = user.Id,
                UserName = user.UserName,
                Mobile = user.Mobile,
                RealName = user.RealName,
            });
            return Success(new LoginResponse()
            {
                Authorization = token
            });
        }
        string GetToken(int userId, string userName)
        {
            return MD5Encrypt.Encrypt($"{userId}{userName}{Util.Time()}");
        }
    }
}
