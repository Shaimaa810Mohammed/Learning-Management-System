using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class update_question_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Assessments_AssessmentId",
                table: "QuestionQuiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionQuiz",
                table: "QuestionQuiz");

            migrationBuilder.DropIndex(
                name: "IX_QuestionQuiz_QuestionsId",
                table: "QuestionQuiz");

            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "QuestionQuiz",
                newName: "QuizzesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionQuiz",
                table: "QuestionQuiz",
                columns: new[] { "QuestionsId", "QuizzesId" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_QuizzesId",
                table: "QuestionQuiz",
                column: "QuizzesId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Assessments_QuizzesId",
                table: "QuestionQuiz",
                column: "QuizzesId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Assessments_QuizzesId",
                table: "QuestionQuiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionQuiz",
                table: "QuestionQuiz");

            migrationBuilder.DropIndex(
                name: "IX_QuestionQuiz_QuizzesId",
                table: "QuestionQuiz");

            migrationBuilder.RenameColumn(
                name: "QuizzesId",
                table: "QuestionQuiz",
                newName: "AssessmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionQuiz",
                table: "QuestionQuiz",
                columns: new[] { "AssessmentId", "QuestionsId" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_QuestionsId",
                table: "QuestionQuiz",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Assessments_AssessmentId",
                table: "QuestionQuiz",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
