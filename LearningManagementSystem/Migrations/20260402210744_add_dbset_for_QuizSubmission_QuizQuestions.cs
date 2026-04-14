using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class add_dbset_for_QuizSubmission_QuizQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_ApplicationUserId",
                table: "QuizSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_Assessments_QuizId",
                table: "QuizSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizSubmission",
                table: "QuizSubmission");

            migrationBuilder.RenameTable(
                name: "QuizSubmission",
                newName: "QuizSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_QuizSubmission_QuizId",
                table: "QuizSubmissions",
                newName: "IX_QuizSubmissions_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizSubmissions",
                table: "QuizSubmissions",
                columns: new[] { "ApplicationUserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmissions_AspNetUsers_ApplicationUserId",
                table: "QuizSubmissions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmissions_Assessments_QuizId",
                table: "QuizSubmissions",
                column: "QuizId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmissions_AspNetUsers_ApplicationUserId",
                table: "QuizSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmissions_Assessments_QuizId",
                table: "QuizSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizSubmissions",
                table: "QuizSubmissions");

            migrationBuilder.RenameTable(
                name: "QuizSubmissions",
                newName: "QuizSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_QuizSubmissions_QuizId",
                table: "QuizSubmission",
                newName: "IX_QuizSubmission_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizSubmission",
                table: "QuizSubmission",
                columns: new[] { "ApplicationUserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_ApplicationUserId",
                table: "QuizSubmission",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_Assessments_QuizId",
                table: "QuizSubmission",
                column: "QuizId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
