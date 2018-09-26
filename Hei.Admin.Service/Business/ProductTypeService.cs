using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// ProductTypeService 
    /// </summary>
    public class ProductTypeService: BaseService<ProductType>  
    {    
		private readonly IProductTypeRepository _productTypeRepository;
		public ProductTypeService(IProductTypeRepository productTypeRepository)
			:base(productTypeRepository)
		{
			_productTypeRepository = productTypeRepository;
		}
    }
}
    
