using Hei.Admin.IRepository.Basic;
using Hei.Admin.Repository.Basic;
using Hei.Admin.Service.Basic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hei.Admin.Api.Controllers
{
    [Route("api/[controller]"), Authorize]
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
        public ViewModel.ApiActionResult<string[]> Get()
        {
            var aa = _sysUserService.FirstOrDefault(a => a.Id == 3);

            var aaa = _sysUserService.GetUser();
            _SysMenuRoleService.Find(1);

            return Success(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ViewModel.ApiActionResult Get(int id)
        {
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
