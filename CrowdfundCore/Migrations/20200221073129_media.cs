using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundCore.Migrations
{
    public partial class media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "video",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCreator_Id",
                table: "ProjectCreator",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectCreator_Id",
                table: "ProjectCreator");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "video",
                table: "Project");
        }
    }
}
