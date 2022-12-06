using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boolflix.Migrations
{
    /// <inheritdoc />
    public partial class AddContentToDbQuery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastContent_Content_ContentsId",
                table: "CastContent");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenre_Content_ContentsId",
                table: "ContentGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Content_SerieTVId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CastContent_Contents_ContentsId",
                table: "CastContent",
                column: "ContentsId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenre_Contents_ContentsId",
                table: "ContentGenre",
                column: "ContentsId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Contents_SerieTVId",
                table: "Seasons",
                column: "SerieTVId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastContent_Contents_ContentsId",
                table: "CastContent");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenre_Contents_ContentsId",
                table: "ContentGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Contents_SerieTVId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CastContent_Content_ContentsId",
                table: "CastContent",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenre_Content_ContentsId",
                table: "ContentGenre",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Content_SerieTVId",
                table: "Seasons",
                column: "SerieTVId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
