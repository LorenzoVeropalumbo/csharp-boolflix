using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boolflix.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number_Episode",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Content");

            migrationBuilder.AddColumn<int>(
                name: "PG",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Content",
                type: "text",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Remaining_time",
                table: "Content",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PG",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Remaining_time",
                table: "Content");

            migrationBuilder.AddColumn<int>(
                name: "Number_Episode",
                table: "Content",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Content",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
