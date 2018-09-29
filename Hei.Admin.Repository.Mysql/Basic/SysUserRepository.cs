using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Basic
{
    /// <summary>
    /// SysUserRepository 
    /// </summary>
    public class SysUserRepository : BaseRepository<SysUser>, ISysUserRepository
    {
        public SysUserRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}

