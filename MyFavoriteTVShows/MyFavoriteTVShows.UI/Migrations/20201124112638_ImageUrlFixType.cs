using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFavoriteTVShows.UI.Migrations
{
    public partial class ImageUrlFixType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "TVShow",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ImageURL",
                table: "TVShow",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
