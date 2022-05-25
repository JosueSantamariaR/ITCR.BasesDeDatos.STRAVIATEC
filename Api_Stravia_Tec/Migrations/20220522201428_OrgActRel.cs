using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Stravia_Tec.Migrations
{
    public partial class OrgActRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Athletes",
                newName: "birth_date");

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityOrganizer",
                columns: table => new
                {
                    Activitiesid = table.Column<int>(type: "int", nullable: false),
                    OrganizersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOrganizer", x => new { x.Activitiesid, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_ActivityOrganizer_Activities_Activitiesid",
                        column: x => x.Activitiesid,
                        principalTable: "Activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityOrganizer_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOrganizer_OrganizersId",
                table: "ActivityOrganizer",
                column: "OrganizersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityOrganizer");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Athletes",
                newName: "birthdate");
        }
    }
}
