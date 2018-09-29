using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Basic
{    
    /// <summary>
    /// SysRoleRepository 
    /// </summary>
    public class SysRoleRepository: BaseRepository<SysRole>,ISysRoleRepository
    {
        public SysRoleRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
