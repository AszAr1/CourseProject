using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kinopoisk.Migrations
{
    /// <inheritdoc />
    public partial class ChageGenreTableNameAndAddMoviesGenresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_genres",
                table: "movie_genres");

            migrationBuilder.RenameTable(
                name: "movie_genres",
                newName: "genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "movie_genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_genres",
                table: "movie_genres",
                column: "id");
        }
    }
}
