﻿// <auto-generated />
using System;
using Hei.Admin.Repository.Mysql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hei.Admin.Repository.Mysql.Migrations
{
    [DbContext(typeof(HuachMysqlDbContext))]
    [Migration("20180929112322_HeiMysqlMigration5")]
    partial class HeiMysqlMigration5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hei.Admin.Models.Basic.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<string>("ExternalUrl")
                        .HasMaxLength(200);

                    b.Property<string>("ImgUrl")
                        .HasMaxLength(200);

                    b.Property<bool>("IsExternal");

                    b.Property<bool>("IsPublish");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("ReadCount");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("t_news");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Brand");

                    b.Property<long>("Code");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<bool>("IsPublish");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductTypeId");

                    b.Property<int>("Qty");

                    b.Property<int>("ReadCount");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<short>("Type");

                    b.HasKey("Id");

                    b.ToTable("t_product");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.ProductAttr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("ProductTypeId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("t_product_attr");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasMaxLength(30);

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("t_product_type");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("DictionaryTypeCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("DictionaryTypeId");

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("ParentId");

                    b.Property<int>("Sort");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("sys_dictionary");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysDictionaryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("sys_dictionary_type");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<short>("Type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("sys_logs");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ParentId");

                    b.Property<int>("Sort");

                    b.Property<string>("Url")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("sys_menu");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysMenuRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<int>("MenuId");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("sys_menu_role");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Code");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<short>("Level");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("sys_region");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("sys_role");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addr")
                        .HasMaxLength(500);

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("IDCard")
                        .HasMaxLength(18);

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("ParentId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<short>("Type");

                    b.Property<string>("UserImg")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("sys_user");
                });

            modelBuilder.Entity("Hei.Admin.Models.Basic.SysUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("sys_user_role");
                });

            modelBuilder.Entity("Hei.Admin.Models.Business.AdvertisingImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(5000);

                    b.Property<short>("Disable");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<short>("Type");

                    b.Property<string>("Url")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("t_advertising_image");
                });

            modelBuilder.Entity("Hei.Admin.Models.Business.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(10);

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<short>("Disable");

                    b.Property<string>("Email")
                        .HasMaxLength(30);

                    b.Property<double>("Latitude");

                    b.Property<string>("Logo")
                        .HasMaxLength(200);

                    b.Property<double>("Longitude");

                    b.Property<int>("ModifyBy");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("QQ")
                        .HasMaxLength(10);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("t_company");
                });
#pragma warning restore 612, 618
        }
    }
}