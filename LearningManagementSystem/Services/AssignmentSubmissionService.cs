using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;

namespace LearningManagementSystem.Services
{
	public class AssignmentSubmissionService : IAssignmentSubmissionService
	{
		private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;
		public AssignmentSubmissionService(IAssignmentSubmissionRepository assignmentSubmissionRepository)
		{
			_assignmentSubmissionRepository = assignmentSubmissionRepository;
		}

		public void Add(int assignmentId, string studentId, IFormFile solutionFile)
		{
			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AssignmentSubmissions");
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
			string fileUniqueName = Guid.NewGuid().ToString() + solutionFile.FileName;
			string relativePath = Path.Combine("AssignmentSubmissions", fileUniqueName);
			string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
			using (var stream = new FileStream(absolutePath, FileMode.Create))
			{
				solutionFile.CopyTo(stream);
			}

			AssignmentSubmission assignmentSubmission = new AssignmentSubmission()
			{
				AssignmentId = assignmentId,
				ApplicationUserId = studentId,
				SolutionFilePath = relativePath,
				Degree = 0,
				IsChecked = false,
				SubmittedAt = DateTime.Now
			};

			_assignmentSubmissionRepository.Add(assignmentSubmission);
		}

		public AssignmentSubmission? GetById(int assignmentId, string studentId)
		{
			return _assignmentSubmissionRepository.GetById(assignmentId, studentId);
		}

		public List<AssignmentSubmission> GetUncheckedAssignmentSubmissions(int assignmentId)
		{
			return _assignmentSubmissionRepository.GetUncheckedAssignmentSubmissions(assignmentId);
		}

		public void SaveSubmissionDegree(int assignmentId, string studentId, int degree)
		{
			AssignmentSubmission? assignmentSubmission = GetById(assignmentId, studentId);
			assignmentSubmission.Degree = degree;
			assignmentSubmission.IsChecked = true;
			_assignmentSubmissionRepository.Update(assignmentSubmission);
		}
	}
}
