using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrimOrganizerV2.Data.Migrations
{
    public partial class BookedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTeam");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookedDate",
                table: "VersusTeam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedDate",
                table: "VersusTeam");

            migrationBuilder.CreateTable(
                name: "MyTeam",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTeam", x => x.ID);
                });
        }
    }
}
