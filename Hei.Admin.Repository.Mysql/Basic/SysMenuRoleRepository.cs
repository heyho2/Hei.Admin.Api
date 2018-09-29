using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Basic
{
    /// <summary>
    /// SysMenuRoleRepository 
    /// </summary>
    public class SysMenuRoleRepository : BaseRepository<SysMenuRole>, ISysMenuRoleRepository
    {
        public SysMenuRoleRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}

