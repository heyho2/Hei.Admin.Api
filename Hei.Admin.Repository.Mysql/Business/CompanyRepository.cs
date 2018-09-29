using Hei.Admin.IRepository.Business;
using Hei.Admin.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql.Business
{    
    /// <summary>
    /// CompanyRepository 
    /// </summary>
    public class CompanyRepository: BaseRepository<Company>,ICompanyRepository
    {
        public CompanyRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
    
