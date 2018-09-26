using Hei.Admin.IRepository.Business;
using Hei.Admin.Models.Business;

namespace Hei.Admin.Service.Business
{    
    /// <summary>
    /// AdvertisingImageService 
    /// </summary>
    public class AdvertisingImageService: BaseService<AdvertisingImage>  
    {    
		private readonly IAdvertisingImageRepository _advertisingImageRepository;
		public AdvertisingImageService(IAdvertisingImageRepository advertisingImageRepository)
			:base(advertisingImageRepository)
		{
			_advertisingImageRepository = advertisingImageRepository;
		}
    }
}
    
