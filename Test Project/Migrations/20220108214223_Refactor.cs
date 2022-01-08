using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Project.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                table: "Songs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
