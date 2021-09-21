using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class showroomChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowroomId",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShowroomId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Showrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsAuthorizedCompany = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showrooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ShowroomId",
                table: "Cars",
                column: "ShowroomId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShowroomId",
                table: "AspNetUsers",
                column: "ShowroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Showrooms_ShowroomId",
                table: "AspNetUsers",
                column: "ShowroomId",
                principalTable: "Showrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Showrooms_ShowroomId",
                table: "Cars",
                column: "ShowroomId",
                principalTable: "Showrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Showrooms_ShowroomId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Showrooms_ShowroomId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Showrooms");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ShowroomId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShowroomId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShowroomId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ShowroomId",
                table: "AspNetUsers");
        }
    }
}
