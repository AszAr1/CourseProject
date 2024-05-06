using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieCountryTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCountries_countries_country_id",
                table: "MovieCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCountries_movies_movie_id",
                table: "MovieCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCountries",
                table: "MovieCountries");

            migrationBuilder.RenameTable(
                name: "MovieCountries",
                newName: "movies_countries");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCountries_movie_id",
                table: "movies_countries",
                newName: "IX_movies_countries_movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCountries_country_id",
                table: "movies_countries",
                newName: "IX_movies_countries_country_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies_countries",
                table: "movies_countries",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_countries_countries_country_id",
                table: "movies_countries",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_countries_movies_movie_id",
                table: "movies_countries",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_countries_countries_country_id",
                table: "movies_countries");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_countries_movies_movie_id",
                table: "movies_countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies_countries",
                table: "movies_countries");

            migrationBuilder.RenameTable(
                name: "movies_countries",
                newName: "MovieCountries");

            migrationBuilder.RenameIndex(
                name: "IX_movies_countries_movie_id",
                table: "MovieCountries",
                newName: "IX_MovieCountries_movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_movies_countries_country_id",
                table: "MovieCountries",
                newName: "IX_MovieCountries_country_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCountries",
                table: "MovieCountries",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCountries_countries_country_id",
                table: "MovieCountries",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCountries_movies_movie_id",
                table: "MovieCountries",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
