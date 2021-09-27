using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class pricedatatypechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Services",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Price50",
                table: "AutoParts",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Price100",
                table: "AutoParts",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "AutoParts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ListPrice",
                table: "AutoParts",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Price50",
                table: "AutoParts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Price100",
                table: "AutoParts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "AutoParts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "ListPrice",
                table: "AutoParts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
