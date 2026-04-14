using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class update_Assessment_and_Assignment_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Assessments",
                newName: "MaxDegree");

            migrationBuilder.AddColumn<string>(
                name: "AssignmentFilePath",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Assessments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentFilePath",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "MaxDegree",
                table: "Assessments",
                newName: "Duration");

            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
