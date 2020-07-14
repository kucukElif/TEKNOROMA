using Microsoft.EntityFrameworkCore.Migrations;

namespace TeknoromaUI.Migrations
{
    public partial class addProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalesNo",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TC",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesNo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TC",
                table: "Customers");
        }
    }
}
