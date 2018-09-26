using Hei.Admin.Models.Basic;
using Hei.Admin.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository
{
    public class HuachDbContext : DbContext
    {
        //private Logger logger = Logger.CreateLogger(typeof(HuachDbContext));
        public HuachDbContext(DbContextOptions<HuachDbContext> options) : base(options)
        {
           
        }
        static HuachDbContext()
        {
        }
        public virtual DbSet<SysUser> SysUserInfoSet { get; set; }
        public virtual DbSet<SysUserRole> SysUserRoleSet { get; set; }
        public virtual DbSet<SysDictionary> SysDictionarySet { get; set; }
        public virtual DbSet<SysDictionaryType> SysDictionaryTypeSet { get; set; }
        public virtual DbSet<SysMenu> SysMenuSet { get; set; }
        public virtual DbSet<SysMenuRole> SysMenuRoleSet { get; set; }
        public virtual DbSet<SysRegion> SysRegionSet { get; set; }
        public virtual DbSet<SysRole> SysRoleSet { get; set; }
        public virtual DbSet<SysLogs> SysLogsSet { get; set; }
        public virtual DbSet<AdvertisingImage> AdvertisingImageSet { get; set; }
        public virtual DbSet<Company> CompanySet { get; set; }
        public virtual DbSet<News> NewsSet { get; set; }
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<ProductAttr> ProductAttrSet { get; set; }
        public virtual DbSet<ProductType> ProductTypeSet { get; set; }

    }
}
