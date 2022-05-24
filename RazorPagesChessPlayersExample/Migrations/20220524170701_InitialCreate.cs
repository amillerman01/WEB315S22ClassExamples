using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesChessPlayersExample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChessPlayer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfTitleAcquisition = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentRating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessPlayer", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChessPlayer");
        }
    }
}
