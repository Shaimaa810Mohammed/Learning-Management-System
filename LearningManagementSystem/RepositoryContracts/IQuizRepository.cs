using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IQuizRepository
	{
		void Add(Quiz quiz);

		Quiz? GetById (int id);

		void Update(Quiz quiz);

		void Delete(Quiz quiz);

		void AddQuizQuestion(QuizQuestion quizQuestion);

		List<QuizQuestion> GetQuizQuestions(int quizId);

		void DeleteQuizQuestion(QuizQuestion quizQuestion);
	}
}
