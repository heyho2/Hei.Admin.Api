using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Basic
{    
    /// <summary>
    /// ProductTypeRepository 
    /// </summary>
    public class ProductTypeRepository: BaseRepository<ProductType>,IProductTypeRepository
    {
        public ProductTypeRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
