using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class ondelecasonorderdetail3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHeaders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                table: "OrderHeaders");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderHeaders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHeaders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                table: "OrderHeaders");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderHeaders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
