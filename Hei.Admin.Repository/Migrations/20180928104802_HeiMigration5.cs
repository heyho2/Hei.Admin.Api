using Microsoft.EntityFrameworkCore.Migrations;

namespace Hei.Admin.Repository.Migrations
{
    public partial class HeiMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Type",
                table: "sys_user",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "sys_user",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
