using Hei.Admin.IRepository.Business;
using Hei.Admin.Models.Business;
using Hei.Admin.Repository.Mysql;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Business
{    
    /// <summary>
    /// AdvertisingImageRepository 
    /// </summary>
    public class AdvertisingImageRepository: BaseRepository<AdvertisingImage>,IAdvertisingImageRepository
    {
        public AdvertisingImageRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
