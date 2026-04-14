using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class update_QuizSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxDegree",
                table: "Assessments",
                newName: "TotalDegree");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "QuizSubmissions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "QuizSubmissions");

            migrationBuilder.RenameColumn(
                name: "TotalDegree",
                table: "Assessments",
                newName: "MaxDegree");
        }
    }
}
