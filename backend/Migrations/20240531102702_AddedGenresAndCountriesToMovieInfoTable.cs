using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedGenresAndCountriesToMovieInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MovieInfoModelId",
                table: "genres",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieInfoModelId",
                table: "countries",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_genres_MovieInfoModelId",
                table: "genres",
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
                name: "FK_genres_movie_infos_MovieInfoModelId",
                table: "genres",
                column: "MovieInfoModelId",
                principalTable: "movie_infos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_movie_infos_MovieInfoModelId",
                table: "countries");

            migrationBuilder.DropForeignKey(
                name: "FK_genres_movie_infos_MovieInfoModelId",
                table: "genres");

            migrationBuilder.DropIndex(
                name: "IX_genres_MovieInfoModelId",
                table: "genres");

            migrationBuilder.DropIndex(
                name: "IX_countries_MovieInfoModelId",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "MovieInfoModelId",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "MovieInfoModelId",
                table: "countries");
        }
    }
}
