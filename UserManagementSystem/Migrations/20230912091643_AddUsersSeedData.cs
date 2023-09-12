using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("58cd96c2-6a4c-494a-ad7c-090022a0710b"), "abdelrahman@localeats.com", "Abdelrahman", "Omran", "$2a$11$yoy18ypb41gPTqASazMbG.qRhUD6V57GLhDLJh7nBrpn9NJvkTzHG" },
                    { new Guid("64973898-05bd-42b5-b10c-3b9ab8bcffff"), "mohamed@localeats.com", "Mohamed", "Hesham", "$2a$11$tNIisxr8dllvFKUW.d5if.o1sonXfU.EaxFmAqxlOYMlWtqNdLXau" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("58cd96c2-6a4c-494a-ad7c-090022a0710b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("64973898-05bd-42b5-b10c-3b9ab8bcffff"));
        }
    }
}
