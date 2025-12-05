using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruNguyen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updb8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsSections_News_NewsId",
                table: "NewsSections");

            migrationBuilder.DropIndex(
                name: "IX_NewsSections_NewsId",
                table: "NewsSections");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ParentId",
                table: "Menus",
                column: "ParentId",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ParentId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ParentId",
                table: "Menus");

            migrationBuilder.CreateIndex(
                name: "IX_NewsSections_NewsId",
                table: "NewsSections",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsSections_News_NewsId",
                table: "NewsSections",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
