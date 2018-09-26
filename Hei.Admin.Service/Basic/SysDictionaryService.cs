using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{
    /// <summary>
    /// SysDictionaryService 
    /// </summary>
    public class SysDictionaryService: BaseService<SysDictionary>  
    {    
		private readonly ISysDictionaryRepository _sysDictionaryRepository;
		public SysDictionaryService(ISysDictionaryRepository sysDictionaryRepository)
			:base(sysDictionaryRepository)
		{
			_sysDictionaryRepository = sysDictionaryRepository;
		}
    }
}
    
