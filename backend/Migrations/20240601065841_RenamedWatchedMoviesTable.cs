using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RenamedWatchedMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovieModel_movies_movie_id",
                table: "WatchedMovieModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovieModel_users_user_id",
                table: "WatchedMovieModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchedMovieModel",
                table: "WatchedMovieModel");

            migrationBuilder.RenameTable(
                name: "WatchedMovieModel",
                newName: "watched_movies");

            migrationBuilder.RenameIndex(
                name: "IX_WatchedMovieModel_user_id",
                table: "watched_movies",
                newName: "IX_watched_movies_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_WatchedMovieModel_movie_id",
                table: "watched_movies",
                newName: "IX_watched_movies_movie_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_watched_movies",
                table: "watched_movies",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_watched_movies_movies_movie_id",
                table: "watched_movies",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watched_movies_users_user_id",
                table: "watched_movies",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watched_movies_movies_movie_id",
                table: "watched_movies");

            migrationBuilder.DropForeignKey(
                name: "FK_watched_movies_users_user_id",
                table: "watched_movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_watched_movies",
                table: "watched_movies");

            migrationBuilder.RenameTable(
                name: "watched_movies",
                newName: "WatchedMovieModel");

            migrationBuilder.RenameIndex(
                name: "IX_watched_movies_user_id",
                table: "WatchedMovieModel",
                newName: "IX_WatchedMovieModel_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_watched_movies_movie_id",
                table: "WatchedMovieModel",
                newName: "IX_WatchedMovieModel_movie_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchedMovieModel",
                table: "WatchedMovieModel",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovieModel_movies_movie_id",
                table: "WatchedMovieModel",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovieModel_users_user_id",
                table: "WatchedMovieModel",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
