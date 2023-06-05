using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Infrastructure.Migrations
{
    public partial class SM002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceDate",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalExcl",
                table: "OrderHeaders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalIncl",
                table: "OrderHeaders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTax",
                table: "OrderHeaders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "TotalExcl",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "TotalIncl",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "OrderHeaders");
        }
    }
}
