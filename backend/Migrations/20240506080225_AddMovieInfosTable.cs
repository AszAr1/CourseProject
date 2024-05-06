using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieInfosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_movie_infos_movieInfoId",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "movieInfoId",
                table: "movies",
                newName: "movie_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_movies_movieInfoId",
                table: "movies",
                newName: "IX_movies_movie_info_id");

            migrationBuilder.AddColumn<int>(
                name: "imdb_id",
                table: "movie_infos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "kinopoisk_id",
                table: "movie_infos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name_original",
                table: "movie_infos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name_ru",
                table: "movie_infos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "poster_url",
                table: "movie_infos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "poster_url_preview",
                table: "movie_infos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "rating_imdb",
                table: "movie_infos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rating_kinopoisk",
                table: "movie_infos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "movie_infos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "movie_infos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MovieInfoModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_countries_movie_infos_MovieInfoModelId",
                        column: x => x.MovieInfoModelId,
                        principalTable: "movie_infos",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movie_genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MovieInfoModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movie_genres_movie_infos_MovieInfoModelId",
                        column: x => x.MovieInfoModelId,
                        principalTable: "movie_infos",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_countries_MovieInfoModelId",
                table: "countries",
                column: "MovieInfoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_movie_genres_MovieInfoModelId",
                table: "movie_genres",
                column: "MovieInfoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_movie_infos_movie_info_id",
                table: "movies",
                column: "movie_info_id",
                principalTable: "movie_infos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_movie_infos_movie_info_id",
                table: "movies");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "movie_genres");

            migrationBuilder.DropColumn(
                name: "imdb_id",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "kinopoisk_id",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "name_original",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "name_ru",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "poster_url",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "poster_url_preview",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "rating_imdb",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "rating_kinopoisk",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "type",
                table: "movie_infos");

            migrationBuilder.DropColumn(
                name: "year",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "movie_info_id",
                table: "movies",
                newName: "movieInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_movies_movie_info_id",
                table: "movies",
                newName: "IX_movies_movieInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_movie_infos_movieInfoId",
                table: "movies",
                column: "movieInfoId",
                principalTable: "movie_infos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
