using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundCore.Migrations
{
    public partial class rew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBacker_Backer_BackerId",
                table: "ProjectBacker");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rewards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BackerId",
                table: "ProjectBacker",
                newName: "Backerid");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectBacker_BackerId",
                table: "ProjectBacker",
                newName: "IX_ProjectBacker_Backerid");

            migrationBuilder.RenameColumn(
                name: "video",
                table: "Project",
                newName: "Video");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "Project",
                newName: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBacker_Backer_Backerid",
                table: "ProjectBacker",
                column: "Backerid",
                principalTable: "Backer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBacker_Backer_Backerid",
                table: "ProjectBacker");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rewards",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Backerid",
                table: "ProjectBacker",
                newName: "BackerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectBacker_Backerid",
                table: "ProjectBacker",
                newName: "IX_ProjectBacker_BackerId");

            migrationBuilder.RenameColumn(
                name: "Video",
                table: "Project",
                newName: "video");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Project",
                newName: "photo");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBacker_Backer_BackerId",
                table: "ProjectBacker",
                column: "BackerId",
                principalTable: "Backer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
