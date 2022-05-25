using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Stravia_Tec.Migrations
{
    public partial class GroupOrgActRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGroup",
                columns: table => new
                {
                    Activitiesid = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGroup", x => new { x.Activitiesid, x.GroupId });
                    table.ForeignKey(
                        name: "FK_ActivityGroup_Activities_Activitiesid",
                        column: x => x.Activitiesid,
                        principalTable: "Activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupOrganizer",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    OrganizersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOrganizer", x => new { x.GroupsId, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_GroupOrganizer_Group_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupOrganizer_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityGroup_GroupId",
                table: "ActivityGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOrganizer_OrganizersId",
                table: "GroupOrganizer",
                column: "OrganizersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityGroup");

            migrationBuilder.DropTable(
                name: "GroupOrganizer");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
