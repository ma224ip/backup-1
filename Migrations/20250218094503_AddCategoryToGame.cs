using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cybergames.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68e03ed5-f8eb-4a84-8bad-5be20f3260db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cc3001a-02c6-4ed8-9e65-82a5abc93ee2");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Games",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42765bc4-873d-4575-b59f-36f4c151fd21", null, "admin", "ADMIN" },
                    { "cdbe30ca-8993-4518-aab6-61d55fe127de", null, "client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42765bc4-873d-4575-b59f-36f4c151fd21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdbe30ca-8993-4518-aab6-61d55fe127de");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68e03ed5-f8eb-4a84-8bad-5be20f3260db", null, "client", "CLIENT" },
                    { "9cc3001a-02c6-4ed8-9e65-82a5abc93ee2", null, "admin", "ADMIN" }
                });
        }
    }
}
