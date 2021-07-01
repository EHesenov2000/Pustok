using Microsoft.EntityFrameworkCore.Migrations;

namespace PustokHomework.Migrations
{
    public partial class ArtRedirectUrlsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtBooksRedirectUrlId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtRedirectId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArtUrls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtUrls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ArtBooksRedirectUrlId",
                table: "Books",
                column: "ArtBooksRedirectUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ArtUrls_ArtBooksRedirectUrlId",
                table: "Books",
                column: "ArtBooksRedirectUrlId",
                principalTable: "ArtUrls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ArtUrls_ArtBooksRedirectUrlId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "ArtUrls");

            migrationBuilder.DropIndex(
                name: "IX_Books_ArtBooksRedirectUrlId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ArtBooksRedirectUrlId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ArtRedirectId",
                table: "Books");
        }
    }
}
