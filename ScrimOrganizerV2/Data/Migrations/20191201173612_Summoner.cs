using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrimOrganizerV2.Data.Migrations
{
    public partial class Summoner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summoner",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    profileIconId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    puuid = table.Column<string>(nullable: true),
                    summonerLevel = table.Column<int>(nullable: false),
                    accountId = table.Column<string>(nullable: true),
                    revisionDate = table.Column<long>(nullable: false),
                    teamName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summoner", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summoner");
        }
    }
}
