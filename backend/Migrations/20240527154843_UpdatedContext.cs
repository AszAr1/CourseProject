using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_admin", "is_authorized", "password_digest", "username", "isActive" },
                values: new object[] { new Guid("427954ad-7625-45c5-a76e-3b2363cc1fd6"), "admin@gmail.com", true, false, "Admin", "Admin", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("427954ad-7625-45c5-a76e-3b2363cc1fd6"));
        }
    }
}
