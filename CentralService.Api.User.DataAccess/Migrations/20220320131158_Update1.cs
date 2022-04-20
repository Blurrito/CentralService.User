using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralService.Api.User.DataAccess.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "DeviceProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "DeviceProfiles");
        }
    }
}
