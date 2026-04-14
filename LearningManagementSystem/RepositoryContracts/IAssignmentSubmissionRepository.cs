using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IAssignmentSubmissionRepository
	{
		public void Add(AssignmentSubmission assignmentSubmission);

		public List<AssignmentSubmission> GetUncheckedAssignmentSubmissions(int assignmentId);

		public void Update(AssignmentSubmission assignmentSubmission);

		public AssignmentSubmission? GetById(int assignmentId, string studentId);
	}
}
