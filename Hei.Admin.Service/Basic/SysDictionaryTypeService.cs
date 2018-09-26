using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// SysDictionaryTypeService 
    /// </summary>
    public class SysDictionaryTypeService: BaseService<SysDictionaryType>  
    {    
		private readonly ISysDictionaryTypeRepository _sysDictionaryTypeRepository;
		public SysDictionaryTypeService(ISysDictionaryTypeRepository sysDictionaryTypeRepository)
			:base(sysDictionaryTypeRepository)
		{
			_sysDictionaryTypeRepository = sysDictionaryTypeRepository;
		}
    }
}
    
