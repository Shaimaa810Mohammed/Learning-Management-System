using LearningManagementSystem.Models;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IAssignmentSubmissionService
	{
		public void Add(int assignmentId, string studentId, IFormFile solutionFile);

		public List<AssignmentSubmission> GetUncheckedAssignmentSubmissions(int assignmentId);

		public void SaveSubmissionDegree(int assignmentId, string studentId, int degree);

		public AssignmentSubmission? GetById(int assignmentId, string studentId);
	}
}
