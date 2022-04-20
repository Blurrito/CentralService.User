using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralService.Api.User.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceProfiles",
                columns: table => new
                {
                    DeviceProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceProfiles", x => x.DeviceProfileId);
                });

            migrationBuilder.CreateTable(
                name: "GameProfiles",
                columns: table => new
                {
                    GameProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceProfileId = table.Column<int>(type: "int", nullable: false),
                    GameCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gsbrcd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueNickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pid = table.Column<int>(type: "int", nullable: false),
                    Longnitude = table.Column<float>(type: "real", nullable: false),
                    Lattitude = table.Column<float>(type: "real", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProfiles", x => x.GameProfileId);
                    table.ForeignKey(
                        name: "FK_GameProfiles_DeviceProfiles_DeviceProfileId",
                        column: x => x.DeviceProfileId,
                        principalTable: "DeviceProfiles",
                        principalColumn: "DeviceProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameProfiles_DeviceProfileId",
                table: "GameProfiles",
                column: "DeviceProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameProfiles");

            migrationBuilder.DropTable(
                name: "DeviceProfiles");
        }
    }
}
