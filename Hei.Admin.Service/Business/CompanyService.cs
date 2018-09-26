using Hei.Admin.IRepository.Business;
using Hei.Admin.Models.Business;

namespace Hei.Admin.Service.Business
{    
    /// <summary>
    /// CompanyService 
    /// </summary>
    public class CompanyService: BaseService<Company>  
    {    
		private readonly ICompanyRepository _companyRepository;
		public CompanyService(ICompanyRepository companyRepository)
			:base(companyRepository)
		{
			_companyRepository = companyRepository;
		}
    }
}
    
