using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Basic
{
    /// <summary>
    /// SysDictionaryRepository 
    /// </summary>
    public class SysDictionaryRepository : BaseRepository<SysDictionary>, ISysDictionaryRepository
    {
        public SysDictionaryRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}

