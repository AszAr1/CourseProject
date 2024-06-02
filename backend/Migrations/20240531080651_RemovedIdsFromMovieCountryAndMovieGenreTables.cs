using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIdsFromMovieCountryAndMovieGenreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movies_genres",
                table: "movies_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies_countries",
                table: "movies_countries");

            migrationBuilder.DropColumn(
                name: "id",
                table: "movies_genres");

            migrationBuilder.DropColumn(
                name: "id",
                table: "movies_countries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "movies_genres",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "movies_countries",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies_genres",
                table: "movies_genres",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies_countries",
                table: "movies_countries",
                column: "id");
        }
    }
}
