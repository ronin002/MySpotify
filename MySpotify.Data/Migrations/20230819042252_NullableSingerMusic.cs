using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySpotify.Data.Migrations
{
    public partial class NullableSingerMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Rhythms_RhythmId",
                table: "Musics");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Singers_SingerId",
                table: "Musics");

            migrationBuilder.AlterColumn<Guid>(
                name: "SingerId",
                table: "Musics",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "RhythmId",
                table: "Musics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Rhythms_RhythmId",
                table: "Musics",
                column: "RhythmId",
                principalTable: "Rhythms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Singers_SingerId",
                table: "Musics",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Rhythms_RhythmId",
                table: "Musics");

            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Singers_SingerId",
                table: "Musics");

            migrationBuilder.AlterColumn<Guid>(
                name: "SingerId",
                table: "Musics",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "RhythmId",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Rhythms_RhythmId",
                table: "Musics",
                column: "RhythmId",
                principalTable: "Rhythms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Singers_SingerId",
                table: "Musics",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
