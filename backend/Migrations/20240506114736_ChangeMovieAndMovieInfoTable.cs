using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMovieAndMovieInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countries",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "imdb_id",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "movies",
                newName: "uri");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "movies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "name_ru",
                table: "movie_infos",
                newName: "film_id");

            migrationBuilder.RenameColumn(
                name: "rating_imdb",
                table: "movie_infos",
                newName: "rating_kinopoisk");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "movie_infos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "uri",
                table: "movies",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "movies",
                newName: "path");

            migrationBuilder.RenameColumn(
                name: "film_id",
                table: "movie_infos",
                newName: "name_ru");

            migrationBuilder.RenameColumn(
                name: "rating_kinopoisk",
                table: "movie_infos",
                newName: "rating_imdb");

            migrationBuilder.AddColumn<double>(
                name: "countries",
                table: "movie_infos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "imdb_id",
                table: "movie_infos",
                type: "int",
                nullable: true);
        }
    }
}
