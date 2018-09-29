using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hei.Admin.Repository.Mysql.Migrations
{
    public partial class HeiMysqlMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: false),
                    DictionaryTypeCode = table.Column<string>(maxLength: 50, nullable: false),
                    DictionaryTypeId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dictionary_type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dictionary_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Controller = table.Column<string>(maxLength: 50, nullable: false),
                    Action = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_menu_role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menu_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<long>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Level = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 18, nullable: false),
                    Mobile = table.Column<string>(maxLength: 11, nullable: false),
                    RealName = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<short>(nullable: false),
                    UserImg = table.Column<string>(maxLength: 500, nullable: false),
                    IDCard = table.Column<string>(maxLength: 18, nullable: true),
                    Addr = table.Column<string>(maxLength: 500, nullable: true),
                    IP = table.Column<string>(maxLength: 20, nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_user_role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_advertising_image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<short>(nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_advertising_image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    QQ = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 10, nullable: true),
                    Logo = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_news",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ImgUrl = table.Column<string>(maxLength: 200, nullable: true),
                    IsExternal = table.Column<bool>(nullable: false),
                    ExternalUrl = table.Column<string>(maxLength: 200, nullable: true),
                    ReadCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_news", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brand = table.Column<short>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_product_attr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Value = table.Column<string>(maxLength: 30, nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product_attr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_product_type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: false),
                    Disable = table.Column<short>(nullable: false),
                    Code = table.Column<string>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_product_type", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_dictionary");

            migrationBuilder.DropTable(
                name: "sys_dictionary_type");

            migrationBuilder.DropTable(
                name: "sys_logs");

            migrationBuilder.DropTable(
                name: "sys_menu");

            migrationBuilder.DropTable(
                name: "sys_menu_role");

            migrationBuilder.DropTable(
                name: "sys_region");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "sys_user_role");

            migrationBuilder.DropTable(
                name: "t_advertising_image");

            migrationBuilder.DropTable(
                name: "t_company");

            migrationBuilder.DropTable(
                name: "t_news");

            migrationBuilder.DropTable(
                name: "t_product");

            migrationBuilder.DropTable(
                name: "t_product_attr");

            migrationBuilder.DropTable(
                name: "t_product_type");
        }
    }
}
