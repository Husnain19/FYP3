using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class addCarTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MileageId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationCityId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrimId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mileage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberKm = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mileage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationCity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationCity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolarYear = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFeature", x => new { x.FeatureId, x.Id });
                    table.ForeignKey(
                        name: "FK_CarFeature_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarFeature_Car_Id",
                        column: x => x.Id,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BranId",
                table: "Car",
                column: "BranId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_MileageId",
                table: "Car",
                column: "MileageId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RegistrationCityId",
                table: "Car",
                column: "RegistrationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TransmissionId",
                table: "Car",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TrimId",
                table: "Car",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_YearId",
                table: "Car",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeature_Id",
                table: "CarFeature",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Brand_BranId",
                table: "Car",
                column: "BranId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Mileage_MileageId",
                table: "Car",
                column: "MileageId",
                principalTable: "Mileage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Model_ModelId",
                table: "Car",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_RegistrationCity_RegistrationCityId",
                table: "Car",
                column: "RegistrationCityId",
                principalTable: "RegistrationCity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Transmissions_TransmissionId",
                table: "Car",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Trim_TrimId",
                table: "Car",
                column: "TrimId",
                principalTable: "Trim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Year_YearId",
                table: "Car",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Brand_BranId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Mileage_MileageId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Model_ModelId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_RegistrationCity_RegistrationCityId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Transmissions_TransmissionId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Trim_TrimId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Year_YearId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "CarFeature");

            migrationBuilder.DropTable(
                name: "Mileage");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "RegistrationCity");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "Trim");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Car_BranId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_MileageId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_ModelId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_RegistrationCityId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_TransmissionId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_TrimId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_YearId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BranId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MileageId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RegistrationCityId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TrimId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Car");
        }
    }
}
