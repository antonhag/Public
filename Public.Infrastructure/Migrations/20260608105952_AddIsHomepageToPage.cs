using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Public.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsHomepageToPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHomepage",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHomepage",
                table: "Pages");
        }
    }
}
