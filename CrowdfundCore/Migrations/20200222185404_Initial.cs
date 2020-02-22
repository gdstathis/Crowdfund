using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Donate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCreator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCreator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    budget = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    ProjectCategory = table.Column<int>(nullable: false),
                    photo = table.Column<string>(nullable: true),
                    video = table.Column<string>(nullable: true),
                    BackerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Backer_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCreator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "ProjectCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectBacker",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    BackerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBacker", x => new { x.ProjectId, x.BackerId });
                    table.ForeignKey(
                        name: "FK_ProjectBacker_Backer_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectBacker_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    projectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rewards_Project_projectId",
                        column: x => x.projectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backer_Email",
                table: "Backer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Backer_Phone",
                table: "Backer",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Project_BackerId",
                table: "Project",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Id",
                table: "Project",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBacker_BackerId",
                table: "ProjectBacker",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCreator_Id",
                table: "ProjectCreator",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_projectId",
                table: "Rewards",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_ProjectId",
                table: "Status",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBacker");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Backer");

            migrationBuilder.DropTable(
                name: "ProjectCreator");
        }
    }
}
