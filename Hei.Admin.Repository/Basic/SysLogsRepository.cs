using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Basic
{    
    /// <summary>
    /// SysLogsRepository 
    /// </summary>
    public class SysLogsRepository: BaseRepository<SysLogs>,ISysLogsRepository
    {
        public SysLogsRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
