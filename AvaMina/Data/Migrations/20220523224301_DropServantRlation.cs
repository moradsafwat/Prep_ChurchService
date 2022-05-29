using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaMina.Data.Migrations
{
    public partial class DropServantRlation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Servants_ServantId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ServantId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ServantId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServantId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ServantId",
                table: "Posts",
                column: "ServantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Servants_ServantId",
                table: "Posts",
                column: "ServantId",
                principalTable: "Servants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
