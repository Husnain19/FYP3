using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class orderidrequiredchnages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }
    }
}
