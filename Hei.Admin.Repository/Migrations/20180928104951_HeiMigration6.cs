using Microsoft.EntityFrameworkCore.Migrations;

namespace Hei.Admin.Repository.Migrations
{
    public partial class HeiMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "sys_user",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "sys_user",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
