using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_movie_infos_MovieInfoModelId",
                table: "countries");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_genres_movie_infos_MovieInfoModelId",
                table: "movie_genres");

            migrationBuilder.DropIndex(
                name: "IX_movie_genres_MovieInfoModelId",
                table: "movie_genres");

            migrationBuilder.DropIndex(
                name: "IX_countries_MovieInfoModelId",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "MovieInfoModelId",
                table: "movie_genres");

            migrationBuilder.DropColumn(
                name: "MovieInfoModelId",
                table: "countries");

            migrationBuilder.RenameColumn(
                name: "rating_kinopoisk",
                table: "movie_infos",
                newName: "countries");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "movie_genres",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movie_genres",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "countries",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "countries",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "countries",
                table: "movie_infos",
                newName: "rating_kinopoisk");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "movie_genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "movie_genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "countries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "countries",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "MovieInfoModelId",
                table: "movie_genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieInfoModelId",
                table: "countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movie_genres_MovieInfoModelId",
                table: "movie_genres",
                column: "MovieInfoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_countries_MovieInfoModelId",
                table: "countries",
                column: "MovieInfoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_countries_movie_infos_MovieInfoModelId",
                table: "countries",
                column: "MovieInfoModelId",
                principalTable: "movie_infos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genres_movie_infos_MovieInfoModelId",
                table: "movie_genres",
                column: "MovieInfoModelId",
                principalTable: "movie_infos",
                principalColumn: "id");
        }
    }
}
