using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Project.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "AlbumModelId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumModelId",
                table: "Songs",
                column: "AlbumModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumModelId",
                table: "Songs",
                column: "AlbumModelId",
                principalTable: "Albums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumModelId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumModelId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AlbumModelId",
                table: "Songs");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
