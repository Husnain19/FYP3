using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class ondelecasonorderdetail4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_AutoParts_AutoPartId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_AutoParts_AutoPartId",
                table: "OrderDetails",
                column: "AutoPartId",
                principalTable: "AutoParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_AutoParts_AutoPartId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_AutoParts_AutoPartId",
                table: "OrderDetails",
                column: "AutoPartId",
                principalTable: "AutoParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
