using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Public.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCssStyleFromContentBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CssStyle",
                table: "ContentBlocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CssStyle",
                table: "ContentBlocks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
