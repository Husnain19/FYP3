using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class changeYearTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transmissions_Trims_TrimId",
                table: "Transmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Years_Trims_TrimId",
                table: "Years");

            migrationBuilder.DropIndex(
                name: "IX_Years_TrimId",
                table: "Years");

            migrationBuilder.DropIndex(
                name: "IX_Transmissions_TrimId",
                table: "Transmissions");

            migrationBuilder.DropColumn(
                name: "TrimId",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "TrimId",
                table: "Transmissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrimId",
                table: "Years",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrimId",
                table: "Transmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Years_TrimId",
                table: "Years",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Transmissions_TrimId",
                table: "Transmissions",
                column: "TrimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transmissions_Trims_TrimId",
                table: "Transmissions",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Years_Trims_TrimId",
                table: "Years",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
