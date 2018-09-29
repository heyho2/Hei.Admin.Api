using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Basic
{    
    /// <summary>
    /// SysUserRoleRepository 
    /// </summary>
    public class SysUserRoleRepository: BaseRepository<SysUserRole>,ISysUserRoleRepository
    {
        public SysUserRoleRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
