using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class changesRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);
        }
    }
}
