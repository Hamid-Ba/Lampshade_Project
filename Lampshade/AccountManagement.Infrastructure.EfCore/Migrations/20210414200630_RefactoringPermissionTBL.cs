using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    public partial class RefactoringPermissionTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_PermissionId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Permissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PermissionId",
                table: "Permissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionId",
                table: "Permissions",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_PermissionId",
                table: "Permissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
