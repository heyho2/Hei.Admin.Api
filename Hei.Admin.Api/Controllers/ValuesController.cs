using Hei.Admin.Service.Basic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hei.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseApiController
    {
        public SysUserService _sysUserService;
        public SysMenuRoleService _SysMenuRoleService;
        public ValuesController(SysUserService sysUserService, SysMenuRoleService _SysMenuRoleService)
        {
            _sysUserService = sysUserService;
            this._SysMenuRoleService = _SysMenuRoleService;
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ViewModel.ApiActionResult<string[]>> Get()
        {
            //var aa = _sysUserService.FirstOrDefaultAsync(a => a.Id == 3);
            var aaa = _sysUserService.GetUser();
            await _SysMenuRoleService.FindAsync(1);

            return Success(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}"), AllowAnonymous]
        public ViewModel.ApiActionResult Get(int id)
        {
            throw new Exception("你是失败了");
            return Success("value", "成功");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
