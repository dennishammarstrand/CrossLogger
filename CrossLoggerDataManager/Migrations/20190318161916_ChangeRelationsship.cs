using Microsoft.EntityFrameworkCore.Migrations;

namespace CrossLoggerDataManager.Migrations
{
    public partial class ChangeRelationsship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPersonalRecords");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "PersonalRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRecords_UserID",
                table: "PersonalRecords",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalRecords_User_UserID",
                table: "PersonalRecords",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalRecords_User_UserID",
                table: "PersonalRecords");

            migrationBuilder.DropIndex(
                name: "IX_PersonalRecords_UserID",
                table: "PersonalRecords");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "PersonalRecords");

            migrationBuilder.CreateTable(
                name: "UserPersonalRecords",
                columns: table => new
                {
                    PersonalRecordID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalRecords", x => new { x.PersonalRecordID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserPersonalRecords_PersonalRecords_PersonalRecordID",
                        column: x => x.PersonalRecordID,
                        principalTable: "PersonalRecords",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPersonalRecords_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalRecords_UserID",
                table: "UserPersonalRecords",
                column: "UserID");
        }
    }
}
