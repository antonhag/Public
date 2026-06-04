using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Public.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HeadingColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadingFont = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadingSize = table.Column<int>(type: "int", nullable: false),
                    TextColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFont = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextSize = table.Column<int>(type: "int", nullable: false),
                    ImageBorderRadius = table.Column<int>(type: "int", nullable: false),
                    ImageBorderColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUnderline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteStyles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteStyles");
        }
    }
}
