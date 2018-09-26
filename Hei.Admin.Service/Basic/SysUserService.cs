using Hei.Admin.Core;
using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Service.Basic
{
    /// <summary>
    /// SysUserService 
    /// </summary>
    public class SysUserService : BaseService<SysUser>
    {
        private readonly ISysUserRepository _sysUserRepository;
        public SysUserService(ISysUserRepository sysUserRepository)
            : base(sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }

        public SysUser GetUser()
        {
            return _sysUserRepository.DbContext.Set<SysUser>().Find(1);

        }
    }
}

