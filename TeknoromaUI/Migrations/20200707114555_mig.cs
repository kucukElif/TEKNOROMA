using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeknoromaUI.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrderID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrderID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrderID",
                table: "Customers",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderID",
                table: "Customers",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
