using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Basic
{    
    /// <summary>
    /// SysMenuRepository 
    /// </summary>
    public class SysMenuRepository: BaseRepository<SysMenu>,ISysMenuRepository
    {
        public SysMenuRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
