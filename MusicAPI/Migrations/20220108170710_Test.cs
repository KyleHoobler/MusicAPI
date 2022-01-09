using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Project.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Songs",
                newName: "AlbumID");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                newName: "IX_Songs_AlbumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "Songs",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                newName: "IX_Songs_AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
