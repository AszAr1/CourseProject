using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMovieInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("340e8aad-0695-4fd6-9413-e3fdb46c207e"));

            migrationBuilder.UpdateData(
                table: "movie_infos",
                keyColumn: "name_en",
                keyValue: null,
                column: "name_en",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name_en",
                table: "movie_infos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name_original",
                table: "movie_infos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_original",
                table: "movie_infos");

            migrationBuilder.AlterColumn<string>(
                name: "name_en",
                table: "movie_infos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_admin", "is_authorized", "password_digest", "username", "is_active" },
                values: new object[] { new Guid("340e8aad-0695-4fd6-9413-e3fdb46c207e"), "admin@gmail.com", true, false, "Admin", "Admin", true });
        }
    }
}
