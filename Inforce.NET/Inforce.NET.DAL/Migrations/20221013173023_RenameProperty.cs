using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inforce.NET.DAL.Migrations
{
    public partial class RenameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortdUrl",
                table: "ShortedUrls",
                newName: "ShortUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortUrl",
                table: "ShortedUrls",
                newName: "ShortdUrl");
        }
    }
}
