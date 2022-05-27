using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Stravia_Tec.Migrations
{
    public partial class RebuildConcepModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Athletes_AthleteId",
                table: "Challenges");

            migrationBuilder.DropTable(
                name: "OrganizerReport");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Races",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "AthleteId",
                table: "Challenges",
                newName: "activityTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_Challenges_AthleteId",
                table: "Challenges",
                newName: "IX_Challenges_activityTypeid");

            migrationBuilder.AddColumn<int>(
                name: "activityTypeid",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Organizers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "current_age",
                table: "Athletes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTypeid",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isChallengeRace",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOrganizer",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    OrganizersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOrganizer", x => new { x.CategoriesId, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_CategoryOrganizer_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryOrganizer_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_activityTypeid",
                table: "Races",
                column: "activityTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Races_categoryId",
                table: "Races",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_RouteId",
                table: "Organizers",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeid",
                table: "Activities",
                column: "ActivityTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOrganizer_OrganizersId",
                table: "CategoryOrganizer",
                column: "OrganizersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeid",
                table: "Activities",
                column: "ActivityTypeid",
                principalTable: "ActivityTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_ActivityTypes_activityTypeid",
                table: "Challenges",
                column: "activityTypeid",
                principalTable: "ActivityTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Routes_RouteId",
                table: "Organizers",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_ActivityTypes_activityTypeid",
                table: "Races",
                column: "activityTypeid",
                principalTable: "ActivityTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Categories_categoryId",
                table: "Races",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTypes_ActivityTypeid",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_ActivityTypes_activityTypeid",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Routes_RouteId",
                table: "Organizers");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_ActivityTypes_activityTypeid",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Categories_categoryId",
                table: "Races");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "CategoryOrganizer");

            migrationBuilder.DropIndex(
                name: "IX_Races_activityTypeid",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_categoryId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_RouteId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTypeid",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "activityTypeid",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "current_age",
                table: "Athletes");

            migrationBuilder.DropColumn(
                name: "ActivityTypeid",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "isChallengeRace",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Races",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "activityTypeid",
                table: "Challenges",
                newName: "AthleteId");

            migrationBuilder.RenameIndex(
                name: "IX_Challenges_activityTypeid",
                table: "Challenges",
                newName: "IX_Challenges_AthleteId");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registered_time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerReport",
                columns: table => new
                {
                    OrganizersId = table.Column<int>(type: "int", nullable: false),
                    ReportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerReport", x => new { x.OrganizersId, x.ReportsId });
                    table.ForeignKey(
                        name: "FK_OrganizerReport_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizerReport_Reports_ReportsId",
                        column: x => x.ReportsId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizerReport_ReportsId",
                table: "OrganizerReport",
                column: "ReportsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Athletes_AthleteId",
                table: "Challenges",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "id");
        }
    }
}
