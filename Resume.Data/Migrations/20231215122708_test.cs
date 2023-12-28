using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostComments",
                table: "blogPostComments");

            migrationBuilder.RenameTable(
                name: "blogPostComments",
                newName: "BlogPostComments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostComments",
                table: "BlogPostComments",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostComments",
                table: "BlogPostComments");

            migrationBuilder.RenameTable(
                name: "BlogPostComments",
                newName: "blogPostComments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostComments",
                table: "blogPostComments",
                column: "Id");
        }
    }
}
