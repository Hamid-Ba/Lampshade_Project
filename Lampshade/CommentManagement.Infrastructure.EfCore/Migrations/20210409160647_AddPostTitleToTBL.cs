using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentManagement.Infrastructure.EfCore.Migrations
{
    public partial class AddPostTitleToTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Comments");
        }
    }
}
