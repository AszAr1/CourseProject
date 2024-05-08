using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNamesAndAddMovieGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kinopoisk_id",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "name_original",
                table: "movie_infos",
                newName: "name_en");

            migrationBuilder.AlterColumn<int>(
                name: "film_id",
                table: "movie_infos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name_ru",
                table: "movie_infos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_ru",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "name_en",
                table: "movie_infos",
                newName: "name_original");

            migrationBuilder.AlterColumn<string>(
                name: "film_id",
                table: "movie_infos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "kinopoisk_id",
                table: "movie_infos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
