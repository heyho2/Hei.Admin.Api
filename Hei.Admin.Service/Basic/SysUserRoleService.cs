using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysUserRoleService 
    /// </summary>
    public class SysUserRoleService: BaseService<SysUserRole>  
    {    
		private readonly ISysUserRoleRepository _sysUserRoleRepository;
		public SysUserRoleService(ISysUserRoleRepository sysUserRoleRepository)
			:base(sysUserRoleRepository)
		{
			_sysUserRoleRepository = sysUserRoleRepository;
		}
    }
}
    
