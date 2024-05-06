using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_movie_infos_MovieInfoId",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "movies",
                newName: "path");

            migrationBuilder.RenameColumn(
                name: "MovieInfoId",
                table: "movies",
                newName: "movieInfoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movies",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_movies_MovieInfoId",
                table: "movies",
                newName: "IX_movies_movieInfoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movie_infos",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_movie_infos_movieInfoId",
                table: "movies",
                column: "movieInfoId",
                principalTable: "movie_infos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_movie_infos_movieInfoId",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "movies",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "movieInfoId",
                table: "movies",
                newName: "MovieInfoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "movies",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_movies_movieInfoId",
                table: "movies",
                newName: "IX_movies_MovieInfoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "movie_infos",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_movie_infos_MovieInfoId",
                table: "movies",
                column: "MovieInfoId",
                principalTable: "movie_infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
