using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class orderidrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");
        }
    }
}
