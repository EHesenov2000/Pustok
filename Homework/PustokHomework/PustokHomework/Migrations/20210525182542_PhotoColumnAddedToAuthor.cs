using Microsoft.EntityFrameworkCore.Migrations;

namespace PustokHomework.Migrations
{
    public partial class PhotoColumnAddedToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Authors",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Authors");
        }
    }
}
