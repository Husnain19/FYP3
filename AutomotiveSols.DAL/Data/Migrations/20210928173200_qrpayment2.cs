using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class qrpayment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QRs_Cars_CarId",
                table: "QRs");

            migrationBuilder.DropIndex(
                name: "IX_QRs_CarId",
                table: "QRs");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "QRs");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "QRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRs_CarId",
                table: "QRs",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_QRs_Cars_CarId",
                table: "QRs",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
