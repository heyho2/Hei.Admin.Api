using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysRoleService 
    /// </summary>
    public class SysRoleService: BaseService<SysRole>  
    {    
		private readonly ISysRoleRepository _sysRoleRepository;
		public SysRoleService(ISysRoleRepository sysRoleRepository)
			:base(sysRoleRepository)
		{
			_sysRoleRepository = sysRoleRepository;
		}
    }
}
    
