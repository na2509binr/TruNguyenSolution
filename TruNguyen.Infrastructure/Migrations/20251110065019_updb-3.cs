using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruNguyen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowMenu",
                table: "CategoryProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowMenu",
                table: "CategoryProducts");
        }
    }
}
