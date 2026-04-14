using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.Services
{
	public class AssignmentService : IAssignmentService
	{
		private readonly IAssignmentRepository _assignmentRepository;
		public AssignmentService(IAssignmentRepository assignmentRepository)
		{
			_assignmentRepository = assignmentRepository;
		}


		public void Add(AssignmentViewModel assignmentViewModel)
		{
			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assignments");
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
			string fileUniqueName = Guid.NewGuid().ToString() + assignmentViewModel.AssignmentFile.FileName;
			string relativePath = Path.Combine("Assignments", fileUniqueName);
			string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
			using (var stream = new FileStream(absolutePath, FileMode.Create))
			{
				assignmentViewModel.AssignmentFile.CopyTo(stream);
			}
			Assignment assignment = new Assignment()
			{
				Title = assignmentViewModel.Title,
				StartTime = assignmentViewModel.StartTime,
				EndTime = assignmentViewModel.EndTime,
				CourseId = assignmentViewModel.CourseId,
				TotalDegree = assignmentViewModel.MaxDegree,
				AssignmentFilePath = relativePath,
				AssignmentFileName = assignmentViewModel.AssignmentFile.FileName
			};
			_assignmentRepository.Add(assignment);
		}


		public void Delete(int assignmentId)
		{
			Assignment? assignment = GetById(assignmentId);
			string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", assignment.AssignmentFilePath);
			if (File.Exists(fullPath))
			{
				File.Delete(fullPath);
			}
			_assignmentRepository.Delete(assignment);
		}

		public Assignment? GetById(int id)
		{
			return _assignmentRepository.GetById(id);
		}

		public void Update(UpdateAssignmentViewModel updateAssignmentViewModel, int assignmentId)
		{
			Assignment? assignment = GetById(assignmentId);
			assignment.Title = updateAssignmentViewModel.Title;
			assignment.StartTime = updateAssignmentViewModel.StartTime;
			assignment.EndTime = updateAssignmentViewModel.EndTime;
			assignment.TotalDegree = updateAssignmentViewModel.MaxDegree;
			_assignmentRepository.Update(assignment);
		}
	}
}
