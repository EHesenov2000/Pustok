using Microsoft.EntityFrameworkCore.Migrations;

namespace PustokHomework.Migrations
{
    public partial class ArtAuthorUrlColumnAddedToArtsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtAuthorUrl",
                table: "ArtUrls",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtAuthorUrl",
                table: "ArtUrls");
        }
    }
}
