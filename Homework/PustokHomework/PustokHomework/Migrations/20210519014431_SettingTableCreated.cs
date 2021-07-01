using Microsoft.EntityFrameworkCore.Migrations;

namespace PustokHomework.Migrations
{
    public partial class SettingTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLogo = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    SupportPhone = table.Column<string>(maxLength: 25, nullable: true),
                    ContactPhone = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    FooterLogo = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
