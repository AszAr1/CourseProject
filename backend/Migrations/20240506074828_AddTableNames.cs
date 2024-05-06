using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieInfos_MovieInfoId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieInfos",
                table: "MovieInfos");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "MovieInfos",
                newName: "movie_infos");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_MovieInfoId",
                table: "movies",
                newName: "IX_movies_MovieInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_infos",
                table: "movie_infos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_movie_infos_MovieInfoId",
                table: "movies",
                column: "MovieInfoId",
                principalTable: "movie_infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_movie_infos_MovieInfoId",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_infos",
                table: "movie_infos");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "movie_infos",
                newName: "MovieInfos");

            migrationBuilder.RenameIndex(
                name: "IX_movies_MovieInfoId",
                table: "Movies",
                newName: "IX_Movies_MovieInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieInfos",
                table: "MovieInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieInfos_MovieInfoId",
                table: "Movies",
                column: "MovieInfoId",
                principalTable: "MovieInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
