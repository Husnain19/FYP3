using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveSols.Data.Migrations
{
    public partial class changenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organization_OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_AspNetUsers_ApplicationUserId",
                table: "AutoPart");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Categories_CategoryId",
                table: "AutoPart");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_SubCategories_SubCategoryId",
                table: "AutoPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoPart",
                table: "AutoPart");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "AutoPart",
                newName: "AutoParts");

            migrationBuilder.RenameIndex(
                name: "IX_AutoPart_SubCategoryId",
                table: "AutoParts",
                newName: "IX_AutoParts_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AutoPart_CategoryId",
                table: "AutoParts",
                newName: "IX_AutoParts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AutoPart_ApplicationUserId",
                table: "AutoParts",
                newName: "IX_AutoParts_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoParts",
                table: "AutoParts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizations_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoParts_AspNetUsers_ApplicationUserId",
                table: "AutoParts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoParts_Categories_CategoryId",
                table: "AutoParts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoParts_SubCategories_SubCategoryId",
                table: "AutoParts",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizations_OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoParts_AspNetUsers_ApplicationUserId",
                table: "AutoParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoParts_Categories_CategoryId",
                table: "AutoParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoParts_SubCategories_SubCategoryId",
                table: "AutoParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoParts",
                table: "AutoParts");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "AutoParts",
                newName: "AutoPart");

            migrationBuilder.RenameIndex(
                name: "IX_AutoParts_SubCategoryId",
                table: "AutoPart",
                newName: "IX_AutoPart_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AutoParts_CategoryId",
                table: "AutoPart",
                newName: "IX_AutoPart_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AutoParts_ApplicationUserId",
                table: "AutoPart",
                newName: "IX_AutoPart_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoPart",
                table: "AutoPart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organization_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_AspNetUsers_ApplicationUserId",
                table: "AutoPart",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Categories_CategoryId",
                table: "AutoPart",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_SubCategories_SubCategoryId",
                table: "AutoPart",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
