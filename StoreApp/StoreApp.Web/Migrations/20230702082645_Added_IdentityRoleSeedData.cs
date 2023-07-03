using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e89566a-78ee-46be-bcda-40c29ea785d7", "7acd9378-1095-4007-ae75-5fbb5fed871d", "Editor", "EDITOR" },
                    { "91c71d8d-3414-4ff4-afcb-b97009ae4505", "3a1f3c2e-8d30-4956-8ab1-b7d5e3077322", "User", "USER" },
                    { "fea68285-b89c-4d14-af84-72895668dc53", "a7a622c0-b389-4db5-a255-937ccfe37b0b", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4e89566a-78ee-46be-bcda-40c29ea785d7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "91c71d8d-3414-4ff4-afcb-b97009ae4505");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fea68285-b89c-4d14-af84-72895668dc53");
        }
    }
}
