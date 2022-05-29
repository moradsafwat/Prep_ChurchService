using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaMina.Data.Migrations
{
    public partial class AssigendminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Security].[UserRoles] (UserId, RoleId) SELECT '2e9b09e7-e33e-46d8-80fd-931a14bff127', Id FROM [Security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Security].[UserRoles] WHERE UserId = '2e9b09e7-e33e-46d8-80fd-931a14bff127'");
        }
    }
}
