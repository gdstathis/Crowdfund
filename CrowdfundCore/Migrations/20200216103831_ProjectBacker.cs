using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundCore.Migrations
{
    public partial class ProjectBacker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Project",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBacker_BackerId",
                table: "ProjectBacker",
                column: "BackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectCreator_CreatorId",
                table: "Project",
                column: "CreatorId",
                principalTable: "ProjectCreator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectCreator_CreatorId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "ProjectBacker");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatorId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Project");
        }
    }
}
