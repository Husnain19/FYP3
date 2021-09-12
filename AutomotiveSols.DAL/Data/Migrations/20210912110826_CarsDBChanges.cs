using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class CarsDBChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrimId",
                table: "Years",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Trims",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Trims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Trims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrimId",
                table: "Transmissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Models",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Years_TrimId",
                table: "Years",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Trims_ModelId",
                table: "Trims",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Trims_TransmissionId",
                table: "Trims",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Trims_YearId",
                table: "Trims",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Transmissions_TrimId",
                table: "Transmissions",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transmissions_Trims_TrimId",
                table: "Transmissions",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_Models_ModelId",
                table: "Trims",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_Transmissions_TransmissionId",
                table: "Trims",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trims_Years_YearId",
                table: "Trims",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Years_Trims_TrimId",
                table: "Years",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Transmissions_Trims_TrimId",
                table: "Transmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Trims_Models_ModelId",
                table: "Trims");

            migrationBuilder.DropForeignKey(
                name: "FK_Trims_Transmissions_TransmissionId",
                table: "Trims");

            migrationBuilder.DropForeignKey(
                name: "FK_Trims_Years_YearId",
                table: "Trims");

            migrationBuilder.DropForeignKey(
                name: "FK_Years_Trims_TrimId",
                table: "Years");

            migrationBuilder.DropIndex(
                name: "IX_Years_TrimId",
                table: "Years");

            migrationBuilder.DropIndex(
                name: "IX_Trims_ModelId",
                table: "Trims");

            migrationBuilder.DropIndex(
                name: "IX_Trims_TransmissionId",
                table: "Trims");

            migrationBuilder.DropIndex(
                name: "IX_Trims_YearId",
                table: "Trims");

            migrationBuilder.DropIndex(
                name: "IX_Transmissions_TrimId",
                table: "Transmissions");

            migrationBuilder.DropIndex(
                name: "IX_Models_BrandId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "TrimId",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Trims");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Trims");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Trims");

            migrationBuilder.DropColumn(
                name: "TrimId",
                table: "Transmissions");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Models");
        }
    }
}
