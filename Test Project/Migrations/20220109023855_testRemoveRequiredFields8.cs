using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Project.Migrations
{
    public partial class testRemoveRequiredFields8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistModelId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumModelId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumModelId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistModelId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "AlbumModelId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ArtistModelId",
                table: "Albums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumModelId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistModelId",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumModelId",
                table: "Songs",
                column: "AlbumModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistModelId",
                table: "Albums",
                column: "ArtistModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistModelId",
                table: "Albums",
                column: "ArtistModelId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumModelId",
                table: "Songs",
                column: "AlbumModelId",
                principalTable: "Albums",
                principalColumn: "Id");
        }
    }
}
