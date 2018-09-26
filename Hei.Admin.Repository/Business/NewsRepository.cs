using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Basic
{    
    /// <summary>
    /// NewsRepository 
    /// </summary>
    public class NewsRepository: BaseRepository<News>,INewsRepository
    {
        public NewsRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
