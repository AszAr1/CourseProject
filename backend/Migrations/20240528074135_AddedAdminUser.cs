using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("fb2b5813-3aff-4a0c-9a94-973cac13fa2c"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_admin", "is_authorized", "password_digest", "username", "is_active" },
                values: new object[] { new Guid("340e8aad-0695-4fd6-9413-e3fdb46c207e"), "admin@gmail.com", true, false, "Admin", "Admin", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("340e8aad-0695-4fd6-9413-e3fdb46c207e"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_admin", "is_authorized", "password_digest", "username", "is_active" },
                values: new object[] { new Guid("fb2b5813-3aff-4a0c-9a94-973cac13fa2c"), "admin@gmail.com", true, false, "Admin", "Admin", true });
        }
    }
}
