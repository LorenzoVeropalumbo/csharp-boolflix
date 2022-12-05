using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boolflix.Migrations
{
    /// <inheritdoc />
    public partial class AddSeasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastContent_Cast_CastsId",
                table: "CastContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Content_SerieTVID",
                table: "Episode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Episode");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "Casts");

            migrationBuilder.RenameColumn(
                name: "SerieTVID",
                table: "Episode",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Episode_SerieTVID",
                table: "Episode",
                newName: "IX_Episode_SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casts",
                table: "Casts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    SerieTVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Content_SerieTVId",
                        column: x => x.SerieTVId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SerieTVId",
                table: "Seasons",
                column: "SerieTVId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastContent_Casts_CastsId",
                table: "CastContent",
                column: "CastsId",
                principalTable: "Casts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Seasons_SeasonId",
                table: "Episode",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastContent_Casts_CastsId",
                table: "CastContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Seasons_SeasonId",
                table: "Episode");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casts",
                table: "Casts");

            migrationBuilder.RenameTable(
                name: "Casts",
                newName: "Cast");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Episode",
                newName: "SerieTVID");

            migrationBuilder.RenameIndex(
                name: "IX_Episode_SeasonId",
                table: "Episode",
                newName: "IX_Episode_SerieTVID");

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "Episode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CastContent_Cast_CastsId",
                table: "CastContent",
                column: "CastsId",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Content_SerieTVID",
                table: "Episode",
                column: "SerieTVID",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
