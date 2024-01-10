using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Data.Migrations
{
    public partial class UserAsEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Employees_EmployeeId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Employees_EmployeeId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageSkills_Employees_EmployeeId",
                table: "LanguageSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Employees_EmployeeId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeSkills_Employees_EmployeeId",
                table: "ProgrammeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftSkills_Employees_EmployeeId",
                table: "SoftSkills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "SoftSkills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SoftSkills_EmployeeId",
                table: "SoftSkills",
                newName: "IX_SoftSkills_UserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ProgrammeSkills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgrammeSkills_EmployeeId",
                table: "ProgrammeSkills",
                newName: "IX_ProgrammeSkills_UserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Portfolios",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Portfolios_EmployeeId",
                table: "Portfolios",
                newName: "IX_Portfolios_UserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "LanguageSkills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageSkills_EmployeeId",
                table: "LanguageSkills",
                newName: "IX_LanguageSkills_UserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Experiences",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_EmployeeId",
                table: "Experiences",
                newName: "IX_Experiences_UserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Educations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_EmployeeId",
                table: "Educations",
                newName: "IX_Educations_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Membership",
                table: "Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "About",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Age",
                schema: "Membership",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "CareerLevel",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationDegree",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "Membership",
                table: "Users",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Membership",
                table: "Users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortLocation",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_UserId",
                table: "BlogPosts",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Users_UserId",
                table: "Educations",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageSkills_Users_UserId",
                table: "LanguageSkills",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Users_UserId",
                table: "Portfolios",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeSkills_Users_UserId",
                table: "ProgrammeSkills",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftSkills_Users_UserId",
                table: "SoftSkills",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_UserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Users_UserId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageSkills_Users_UserId",
                table: "LanguageSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Users_UserId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeSkills_Users_UserId",
                table: "ProgrammeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftSkills_Users_UserId",
                table: "SoftSkills");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "About",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Age",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CareerLevel",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EducationDegree",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShortLocation",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SoftSkills",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_SoftSkills_UserId",
                table: "SoftSkills",
                newName: "IX_SoftSkills_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProgrammeSkills",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgrammeSkills_UserId",
                table: "ProgrammeSkills",
                newName: "IX_ProgrammeSkills_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Portfolios",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios",
                newName: "IX_Portfolios_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LanguageSkills",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageSkills_UserId",
                table: "LanguageSkills",
                newName: "IX_LanguageSkills_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Experiences",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                newName: "IX_Experiences_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Educations",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                newName: "IX_Educations_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    About = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    CareerLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    EducationDegree = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ShortLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Employees_EmployeeId",
                table: "Educations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Employees_EmployeeId",
                table: "Experiences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageSkills_Employees_EmployeeId",
                table: "LanguageSkills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Employees_EmployeeId",
                table: "Portfolios",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeSkills_Employees_EmployeeId",
                table: "ProgrammeSkills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftSkills_Employees_EmployeeId",
                table: "SoftSkills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
