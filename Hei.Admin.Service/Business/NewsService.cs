using Hei.Admin.IRepository.Basic;
using Hei.Admin.Models.Basic;

namespace Hei.Admin.Service.Basic
{    
    /// <summary>
    /// NewsService 
    /// </summary>
    public class NewsService: BaseService<News>  
    {    
		private readonly INewsRepository _newsRepository;
		public NewsService(INewsRepository newsRepository)
			:base(newsRepository)
		{
			_newsRepository = newsRepository;
		}
    }
}
    
