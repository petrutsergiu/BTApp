using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.DataAccess.Migrations
{
    public partial class CreateAppDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ValideFrom = table.Column<DateTime>(nullable: false),
                    ValideTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPasswords");
        }
    }
}
