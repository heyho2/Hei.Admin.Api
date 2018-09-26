using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysMenuService 
    /// </summary>
    public class SysMenuService: BaseService<SysMenu>  
    {    
		private readonly ISysMenuRepository _sysMenuRepository;
		public SysMenuService(ISysMenuRepository sysMenuRepository)
			:base(sysMenuRepository)
		{
			_sysMenuRepository = sysMenuRepository;
		}
    }
}
    
