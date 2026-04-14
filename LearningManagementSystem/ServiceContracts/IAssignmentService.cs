using LearningManagementSystem.Models;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IAssignmentService
	{
		public void Add(AssignmentViewModel assignmentViewModel);

		public void Delete(int assignmentId);

		public Assignment? GetById(int id);

		public void Update(UpdateAssignmentViewModel updateAssignmentViewModel, int assignmentId);


	}
}
