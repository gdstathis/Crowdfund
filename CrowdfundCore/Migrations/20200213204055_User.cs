using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundCore.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id_project = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    budget = table.Column<decimal>(nullable: false),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    deadline = table.Column<DateTime>(nullable: false),
                    Creatorid_user = table.Column<int>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    projectCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id_project);
                    table.ForeignKey(
                        name: "FK_Project_User_Creatorid_user",
                        column: x => x.Creatorid_user,
                        principalTable: "User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_Creatorid_user",
                table: "Project",
                column: "Creatorid_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
