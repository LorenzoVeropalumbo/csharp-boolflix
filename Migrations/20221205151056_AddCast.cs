using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boolflix.Migrations
{
    /// <inheritdoc />
    public partial class AddCast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastnome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastContent",
                columns: table => new
                {
                    CastsId = table.Column<int>(type: "int", nullable: false),
                    ContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastContent", x => new { x.CastsId, x.ContentsId });
                    table.ForeignKey(
                        name: "FK_CastContent_Cast_CastsId",
                        column: x => x.CastsId,
                        principalTable: "Cast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastContent_Content_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastContent_ContentsId",
                table: "CastContent",
                column: "ContentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastContent");

            migrationBuilder.DropTable(
                name: "Cast");
        }
    }
}
