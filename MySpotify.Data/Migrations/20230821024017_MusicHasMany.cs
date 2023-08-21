using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySpotify.Data.Migrations
{
    public partial class MusicHasMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Playlists_PlaylistId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_PlaylistId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Musics");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Playlists",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "MusicPlaylist",
                columns: table => new
                {
                    MusicsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PlaylistsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylist", x => new { x.MusicsId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_MusicPlaylist_Musics_MusicsId",
                        column: x => x.MusicsId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylist_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylist_PlaylistsId",
                table: "MusicPlaylist",
                column: "PlaylistsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicPlaylist");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Playlists");

            migrationBuilder.AddColumn<Guid>(
                name: "PlaylistId",
                table: "Musics",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_PlaylistId",
                table: "Musics",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Playlists_PlaylistId",
                table: "Musics",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }
    }
}
