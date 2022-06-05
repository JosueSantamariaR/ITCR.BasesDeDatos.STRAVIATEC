using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Stravia_Tec.Migrations
{
    public partial class test_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Athletes",
                newName: "lname");

            migrationBuilder.RenameColumn(
                name: "lname2",
                table: "Athletes",
                newName: "fname");

            migrationBuilder.RenameColumn(
                name: "lname1",
                table: "Athletes",
                newName: "category");

            migrationBuilder.AlterColumn<int>(
                name: "current_age",
                table: "Athletes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lname",
                table: "Athletes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "fname",
                table: "Athletes",
                newName: "lname2");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Athletes",
                newName: "lname1");

            migrationBuilder.AlterColumn<string>(
                name: "current_age",
                table: "Athletes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
