using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Basic
{    
    /// <summary>
    /// SysDictionaryTypeRepository 
    /// </summary>
    public class SysDictionaryTypeRepository: BaseRepository<SysDictionaryType>,ISysDictionaryTypeRepository
    {
        public SysDictionaryTypeRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
