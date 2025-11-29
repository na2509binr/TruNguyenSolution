using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruNguyen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProducts_CategoryProducts_ParentId",
                table: "CategoryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_CategoryProducts_CategoryProductsId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ParentId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Menus_CategoryProductsId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ParentId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_CategoryProducts_ParentId",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "CategoryProductsId",
                table: "Menus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryProductsId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products",
                column: "CategoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryProductsId",
                table: "Menus",
                column: "CategoryProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_ParentId",
                table: "CategoryProducts",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProducts_CategoryProducts_ParentId",
                table: "CategoryProducts",
                column: "ParentId",
                principalTable: "CategoryProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_CategoryProducts_CategoryProductsId",
                table: "Menus",
                column: "CategoryProductsId",
                principalTable: "CategoryProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ParentId",
                table: "Menus",
                column: "ParentId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products",
                column: "CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
