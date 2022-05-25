using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Stravia_Tec.Migrations
{
    public partial class ChallOrgRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizerRace_Races_RacesId",
                table: "OrganizerRace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Races",
                table: "Races");

            migrationBuilder.RenameTable(
                name: "Races",
                newName: "Race");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Race",
                table: "Race",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeOrganizer",
                columns: table => new
                {
                    ChallengesId = table.Column<int>(type: "int", nullable: false),
                    OrganizersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeOrganizer", x => new { x.ChallengesId, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_ChallengeOrganizer_Challenge_ChallengesId",
                        column: x => x.ChallengesId,
                        principalTable: "Challenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeOrganizer_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeOrganizer_OrganizersId",
                table: "ChallengeOrganizer",
                column: "OrganizersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizerRace_Race_RacesId",
                table: "OrganizerRace",
                column: "RacesId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizerRace_Race_RacesId",
                table: "OrganizerRace");

            migrationBuilder.DropTable(
                name: "ChallengeOrganizer");

            migrationBuilder.DropTable(
                name: "Challenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Race",
                table: "Race");

            migrationBuilder.RenameTable(
                name: "Race",
                newName: "Races");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Races",
                table: "Races",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizerRace_Races_RacesId",
                table: "OrganizerRace",
                column: "RacesId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
