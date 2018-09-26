using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysMenuRoleService 
    /// </summary>
    public class SysMenuRoleService: BaseService<SysMenuRole>  
    {    
		private readonly ISysMenuRoleRepository _sysMenuRoleRepository;
		public SysMenuRoleService(ISysMenuRoleRepository sysMenuRoleRepository)
			:base(sysMenuRoleRepository)
		{
			_sysMenuRoleRepository = sysMenuRoleRepository;
		}
    }
}
    
