using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrimOrganizerV2.Data.Migrations
{
    public partial class versusteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VersusTeam_Team_Team1ID",
                table: "VersusTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_VersusTeam_Team_Team2ID",
                table: "VersusTeam");

            migrationBuilder.DropIndex(
                name: "IX_VersusTeam_Team1ID",
                table: "VersusTeam");

            migrationBuilder.DropIndex(
                name: "IX_VersusTeam_Team2ID",
                table: "VersusTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VersusTeam_Team1ID",
                table: "VersusTeam",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_VersusTeam_Team2ID",
                table: "VersusTeam",
                column: "Team2ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VersusTeam_Team_Team1ID",
                table: "VersusTeam",
                column: "Team1ID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VersusTeam_Team_Team2ID",
                table: "VersusTeam",
                column: "Team2ID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
