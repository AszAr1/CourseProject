using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedKinopoiskIdToMovieInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("427954ad-7625-45c5-a76e-3b2363cc1fd6"));

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "users",
                newName: "is_active");

            migrationBuilder.AddColumn<int>(
                name: "kinopoisk_id",
                table: "movie_infos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_admin", "is_authorized", "password_digest", "username", "is_active" },
                values: new object[] { new Guid("fb2b5813-3aff-4a0c-9a94-973cac13fa2c"), "admin@gmail.com", true, false, "Admin", "Admin", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("fb2b5813-3aff-4a0c-9a94-973cac13fa2c"));

            migrationBuilder.DropColumn(
                name: "kinopoisk_id",
                table: "movie_infos");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "users",
                newName: "isActive");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_admin", "is_authorized", "password_digest", "username", "isActive" },
                values: new object[] { new Guid("427954ad-7625-45c5-a76e-3b2363cc1fd6"), "admin@gmail.com", true, false, "Admin", "Admin", true });
        }
    }
}
