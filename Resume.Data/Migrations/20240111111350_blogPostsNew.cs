using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Data.Migrations
{
    public partial class blogPostsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_Slug",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PublishedBy",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "BlogPosts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "BlogPosts",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishedBy",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "BlogPosts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Slug",
                table: "BlogPosts",
                column: "Slug",
                unique: true);
        }
    }
}
