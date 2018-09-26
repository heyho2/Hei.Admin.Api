using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysRegionService 
    /// </summary>
    public class SysRegionService: BaseService<SysRegion>  
    {    
		private readonly ISysRegionRepository _sysRegionRepository;
		public SysRegionService(ISysRegionRepository sysRegionRepository)
			:base(sysRegionRepository)
		{
			_sysRegionRepository = sysRegionRepository;
		}
    }
}
    
