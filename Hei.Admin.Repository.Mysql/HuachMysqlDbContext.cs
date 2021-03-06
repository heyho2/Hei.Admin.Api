﻿using Hei.Admin.Models;
using Hei.Admin.Models.Basic;
using Hei.Admin.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace Hei.Admin.Repository.Mysql
{
    public class HuachMysqlDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //    .UseMySQL(@"Server=47.106.132.200;database=migrationtest;uid=root;pwd=Password12!;");
        //}
        public HuachMysqlDbContext(DbContextOptions<HuachMysqlDbContext> options) : base(options)
        {
        }
        static HuachMysqlDbContext()
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysUser>()
                .HasQueryFilter(p => p.Disable == (short)BaseModel.DisableEnum.Normal);

            base.OnModelCreating(modelBuilder);
        }
    }
}
