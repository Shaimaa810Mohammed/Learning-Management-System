using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IQuestionRepository
	{
		void Add(Question question);

		List<Question> GetCourseQuestions(int courseId);

		void Update(Question question);

		void Delete(Question question);

		Question? GetById(int id);
	}
}
