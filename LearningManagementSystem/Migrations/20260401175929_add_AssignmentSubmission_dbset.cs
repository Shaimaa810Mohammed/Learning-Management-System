using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class add_AssignmentSubmission_dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_AspNetUsers_ApplicationUserId",
                table: "AssignmentSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_Assessments_AssignmentId",
                table: "AssignmentSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmission",
                newName: "AssignmentSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmission_AssignmentId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions",
                columns: new[] { "ApplicationUserId", "AssignmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_ApplicationUserId",
                table: "AssignmentSubmissions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Assessments_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_AspNetUsers_ApplicationUserId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assessments_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmissions",
                newName: "AssignmentSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId",
                table: "AssignmentSubmission",
                newName: "IX_AssignmentSubmission_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission",
                columns: new[] { "ApplicationUserId", "AssignmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_AspNetUsers_ApplicationUserId",
                table: "AssignmentSubmission",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_Assessments_AssignmentId",
                table: "AssignmentSubmission",
                column: "AssignmentId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
