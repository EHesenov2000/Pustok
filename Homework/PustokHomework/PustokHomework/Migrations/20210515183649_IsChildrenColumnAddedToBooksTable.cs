using Microsoft.EntityFrameworkCore.Migrations;

namespace PustokHomework.Migrations
{
    public partial class IsChildrenColumnAddedToBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChildren",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChildren",
                table: "Books");
        }
    }
}
