using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Business
{    
    /// <summary>
    /// ProductAttrRepository 
    /// </summary>
    public class ProductAttrRepository: BaseRepository<ProductAttr>,IProductAttrRepository
    {
        public ProductAttrRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
