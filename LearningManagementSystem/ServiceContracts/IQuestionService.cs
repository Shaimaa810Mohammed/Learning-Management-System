using LearningManagementSystem.Models;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IQuestionService
	{
		void Add(QuestionViewModel questionViewModel);

		List<Question> GetCourseQuestions(int courseId);

		void Update(QuestionViewModel questionViewModel, int questionId);

		void Delete(int questionId);

		Question? GetById(int id);
	}
}
