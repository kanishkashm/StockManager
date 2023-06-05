using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Infrastructure.Migrations
{
    public partial class SM004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderHeaderId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderHeaderId",
                table: "OrderItems",
                column: "OrderHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderHeaders_OrderHeaderId",
                table: "OrderItems",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderHeaders_OrderHeaderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderHeaderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderHeaderId",
                table: "OrderItems");
        }
    }
}
