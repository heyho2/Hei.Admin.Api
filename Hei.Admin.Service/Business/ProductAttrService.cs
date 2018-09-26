using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// ProductAttrService 
    /// </summary>
    public class ProductAttrService: BaseService<ProductAttr>  
    {    
		private readonly IProductAttrRepository _productAttrRepository;
		public ProductAttrService(IProductAttrRepository productAttrRepository)
			:base(productAttrRepository)
		{
			_productAttrRepository = productAttrRepository;
		}
    }
}
    
