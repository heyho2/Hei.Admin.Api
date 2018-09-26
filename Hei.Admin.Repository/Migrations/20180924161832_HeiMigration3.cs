using Microsoft.EntityFrameworkCore.Migrations;

namespace Hei.Admin.Repository.Migrations
{
    public partial class HeiMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "disssss2",
                table: "sys_menu_role",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "disssss2",
                table: "sys_menu_role");
        }
    }
}
