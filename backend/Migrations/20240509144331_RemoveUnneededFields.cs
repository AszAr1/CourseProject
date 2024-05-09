using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnneededFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kinopoisk_id",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "rating_kinopoisk",
                table: "movie_infos",
                newName: "rating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rating",
                table: "movie_infos",
                newName: "rating_kinopoisk");

            migrationBuilder.AddColumn<int>(
                name: "kinopoisk_id",
                table: "movie_infos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
