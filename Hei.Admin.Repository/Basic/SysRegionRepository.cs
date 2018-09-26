using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Basic
{    
    /// <summary>
    /// SysRegionRepository 
    /// </summary>
    public class SysRegionRepository: BaseRepository<SysRegion>,ISysRegionRepository
    {
        public SysRegionRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
