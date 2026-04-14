using LearningManagementSystem.Models;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface ILessonRepository
	{
		void Add(Lesson lesson);

		Lesson? GetById(int id);

		void Update(Lesson oldLesson);

		void Delete(Lesson lesson);
	}
}
