using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// ProductService 
    /// </summary>
    public class ProductService: BaseService<Product>  
    {    
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
			:base(productRepository)
		{
			_productRepository = productRepository;
		}
    }
}
    
