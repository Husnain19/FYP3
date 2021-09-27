using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class appointmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCar",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isService",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCar",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "isService",
                table: "Appointments");
        }
    }
}
