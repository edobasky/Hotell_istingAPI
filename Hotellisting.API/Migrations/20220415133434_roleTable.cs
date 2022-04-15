using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotellisting.API.Migrations
{
    public partial class roleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ef4f168-106f-4814-9bd5-0fa3408ed17d", "35d7419e-ca9b-4323-9410-57123d32e14b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e81f9e21-c1de-494f-ae4f-cfb37d88d212", "6d4ed309-3f9c-42a4-a739-b11b88e35d75", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ef4f168-106f-4814-9bd5-0fa3408ed17d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e81f9e21-c1de-494f-ae4f-cfb37d88d212");
        }
    }
}
