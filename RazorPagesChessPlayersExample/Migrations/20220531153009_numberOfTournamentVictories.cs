using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesChessPlayersExample.Migrations
{
    public partial class numberOfTournamentVictories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTournamentVictories",
                table: "ChessPlayer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTournamentVictories",
                table: "ChessPlayer");
        }
    }
}
