using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class changesInCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_AspNetUsers_ApplicationUserId",
                table: "Car");

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

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeature_Features_FeatureId",
                table: "CarFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeature_Car_Id",
                table: "CarFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Year",
                table: "Year");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trim",
                table: "Trim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationCity",
                table: "RegistrationCity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mileage",
                table: "Mileage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarFeature",
                table: "CarFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Year",
                newName: "Years");

            migrationBuilder.RenameTable(
                name: "Trim",
                newName: "Trims");

            migrationBuilder.RenameTable(
                name: "RegistrationCity",
                newName: "RegistrationCities");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "Mileage",
                newName: "Mileages");

            migrationBuilder.RenameTable(
                name: "CarFeature",
                newName: "CarFeatures");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_CarFeature_Id",
                table: "CarFeatures",
                newName: "IX_CarFeatures_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Car_YearId",
                table: "Cars",
                newName: "IX_Cars_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_TrimId",
                table: "Cars",
                newName: "IX_Cars_TrimId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_TransmissionId",
                table: "Cars",
                newName: "IX_Cars_TransmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_RegistrationCityId",
                table: "Cars",
                newName: "IX_Cars_RegistrationCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_ModelId",
                table: "Cars",
                newName: "IX_Cars_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_MileageId",
                table: "Cars",
                newName: "IX_Cars_MileageId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_BranId",
                table: "Cars",
                newName: "IX_Cars_BranId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_ApplicationUserId",
                table: "Cars",
                newName: "IX_Cars_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Years",
                table: "Years",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trims",
                table: "Trims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationCities",
                table: "RegistrationCities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mileages",
                table: "Mileages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarFeatures",
                table: "CarFeatures",
                columns: new[] { "FeatureId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Features_FeatureId",
                table: "CarFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Cars_Id",
                table: "CarFeatures",
                column: "Id",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_ApplicationUserId",
                table: "Cars",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BranId",
                table: "Cars",
                column: "BranId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Mileages_MileageId",
                table: "Cars",
                column: "MileageId",
                principalTable: "Mileages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RegistrationCities_RegistrationCityId",
                table: "Cars",
                column: "RegistrationCityId",
                principalTable: "RegistrationCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Trims_TrimId",
                table: "Cars",
                column: "TrimId",
                principalTable: "Trims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Years_YearId",
                table: "Cars",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Features_FeatureId",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Cars_Id",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_ApplicationUserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BranId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Mileages_MileageId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RegistrationCities_RegistrationCityId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Trims_TrimId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Years_YearId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Years",
                table: "Years");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trims",
                table: "Trims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationCities",
                table: "RegistrationCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mileages",
                table: "Mileages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarFeatures",
                table: "CarFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Years",
                newName: "Year");

            migrationBuilder.RenameTable(
                name: "Trims",
                newName: "Trim");

            migrationBuilder.RenameTable(
                name: "RegistrationCities",
                newName: "RegistrationCity");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "Mileages",
                newName: "Mileage");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameTable(
                name: "CarFeatures",
                newName: "CarFeature");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_YearId",
                table: "Car",
                newName: "IX_Car_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_TrimId",
                table: "Car",
                newName: "IX_Car_TrimId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_TransmissionId",
                table: "Car",
                newName: "IX_Car_TransmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_RegistrationCityId",
                table: "Car",
                newName: "IX_Car_RegistrationCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ModelId",
                table: "Car",
                newName: "IX_Car_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_MileageId",
                table: "Car",
                newName: "IX_Car_MileageId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_BranId",
                table: "Car",
                newName: "IX_Car_BranId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_ApplicationUserId",
                table: "Car",
                newName: "IX_Car_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarFeatures_Id",
                table: "CarFeature",
                newName: "IX_CarFeature_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Year",
                table: "Year",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trim",
                table: "Trim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationCity",
                table: "RegistrationCity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mileage",
                table: "Mileage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarFeature",
                table: "CarFeature",
                columns: new[] { "FeatureId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_AspNetUsers_ApplicationUserId",
                table: "Car",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeature_Features_FeatureId",
                table: "CarFeature",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeature_Car_Id",
                table: "CarFeature",
                column: "Id",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
