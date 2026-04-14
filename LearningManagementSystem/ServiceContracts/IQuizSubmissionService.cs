using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IQuizSubmissionService
	{
		void Add(SubmitQuizViewModel submitQuizViewModel);
	}
}
