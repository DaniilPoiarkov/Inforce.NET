using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inforce.NET.DAL.Migrations
{
    public partial class AddedTwoUserModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortedUrls_URL",
                table: "ShortedUrls");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "ShortedUrls",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortdUrl",
                table: "ShortedUrls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Login", "Password", "Role" },
                values: new object[] { 1, "Admin Admin", "admin", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Login", "Password", "Role" },
                values: new object[] { 2, "Guest Guest", "guest", "guest", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ShortedUrls_URL",
                table: "ShortedUrls",
                column: "URL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortedUrls_URL",
                table: "ShortedUrls");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ShortdUrl",
                table: "ShortedUrls");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "ShortedUrls",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ShortedUrls_URL",
                table: "ShortedUrls",
                column: "URL",
                unique: true,
                filter: "[URL] IS NOT NULL");
        }
    }
}
