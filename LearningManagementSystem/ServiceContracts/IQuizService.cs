using LearningManagementSystem.Models;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IQuizService
	{
		void Add(QuizViewModel quizViewModel);

		void Delete(int id);

		Quiz GetById (int id);

		void Update(QuizViewModel quizViewModel, int quizId);

		List<QuizQuestion> GetQuizQuestions(int quizId);


	}
}
