using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdfundCore.Migrations
{
    public partial class addprojectid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Project_projectId",
                table: "Rewards");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Rewards",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Rewards_projectId",
                table: "Rewards",
                newName: "IX_Rewards_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Rewards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Project_ProjectId",
                table: "Rewards",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Project_ProjectId",
                table: "Rewards");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Rewards",
                newName: "projectId");

            migrationBuilder.RenameIndex(
                name: "IX_Rewards_ProjectId",
                table: "Rewards",
                newName: "IX_Rewards_projectId");

            migrationBuilder.AlterColumn<int>(
                name: "projectId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Project_projectId",
                table: "Rewards",
                column: "projectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
