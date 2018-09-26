using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysLogsService 
    /// </summary>
    public class SysLogsService: BaseService<SysLogs>  
    {    
		private readonly ISysLogsRepository _sysLogsRepository;
		public SysLogsService(ISysLogsRepository sysLogsRepository)
			:base(sysLogsRepository)
		{
			_sysLogsRepository = sysLogsRepository;
		}
    }
}
    
