using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipsBetweenTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movies_movie_info_id",
                table: "movies");

            migrationBuilder.CreateIndex(
                name: "IX_movies_movie_info_id",
                table: "movies",
                column: "movie_info_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movies_movie_info_id",
                table: "movies");

            migrationBuilder.CreateIndex(
                name: "IX_movies_movie_info_id",
                table: "movies",
                column: "movie_info_id");
        }
    }
}
