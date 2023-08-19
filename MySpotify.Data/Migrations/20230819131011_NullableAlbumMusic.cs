using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySpotify.Data.Migrations
{
    public partial class NullableAlbumMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Album",
                table: "Musics",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Musics",
                keyColumn: "Album",
                keyValue: null,
                column: "Album",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Album",
                table: "Musics",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
