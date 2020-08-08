using Microsoft.EntityFrameworkCore.Migrations;

namespace TeknoromaUI.Migrations
{
    public partial class intToShort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Quantity",
                table: "Products",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
