using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrimOrganizerV2.Data.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teamName",
                table: "Summoner");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Summoner",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Summoner_TeamID",
                table: "Summoner",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Summoner_Team_TeamID",
                table: "Summoner",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summoner_Team_TeamID",
                table: "Summoner");

            migrationBuilder.DropIndex(
                name: "IX_Summoner_TeamID",
                table: "Summoner");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Summoner");

            migrationBuilder.AddColumn<string>(
                name: "teamName",
                table: "Summoner",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
