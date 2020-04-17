using Microsoft.EntityFrameworkCore.Migrations;

namespace BearstrengthAuthentication.Data.Migrations
{
    public partial class RenameUsersToAthletes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    username = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    fullname = table.Column<string>(name: "full-name", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_email",
                table: "Athletes",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fullname = table.Column<string>(name: "full-name", type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);
        }
    }
}
