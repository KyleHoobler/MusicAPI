using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Project.Migrations
{
    public partial class RemovedDuplicateAlbumID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumID",
                table: "Songs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumID",
                table: "Songs",
                type: "int",
                nullable: true);
        }
    }
}
