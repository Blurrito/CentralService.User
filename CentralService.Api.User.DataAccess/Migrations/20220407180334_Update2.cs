using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralService.Api.User.DataAccess.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buddy",
                columns: table => new
                {
                    BuddyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buddy", x => x.BuddyId);
                    table.ForeignKey(
                        name: "FK_Buddy_GameProfiles_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "GameProfiles",
                        principalColumn: "GameProfileId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Buddy_GameProfiles_SenderId",
                        column: x => x.SenderId,
                        principalTable: "GameProfiles",
                        principalColumn: "GameProfileId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buddy_RecipientId",
                table: "Buddy",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Buddy_SenderId",
                table: "Buddy",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buddy");
        }
    }
}
