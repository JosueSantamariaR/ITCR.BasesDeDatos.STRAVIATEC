using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Stravia_Tec.Migrations
{
    public partial class AthleteLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Athletes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "Athletes");
        }
    }
}
