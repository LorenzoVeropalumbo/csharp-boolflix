using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boolflix.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEpisode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Single_Episode",
                table: "Episodes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Episodes",
                type: "text",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Episodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Episodes");

            migrationBuilder.AddColumn<int>(
                name: "Single_Episode",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
