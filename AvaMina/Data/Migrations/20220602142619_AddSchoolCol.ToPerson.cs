using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaMina.Data.Migrations
{
    public partial class AddSchoolColToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "School",
                table: "People");
        }
    }
}
