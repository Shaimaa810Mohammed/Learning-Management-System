using LearningManagementSystem.Models;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.ServiceContracts
{
	public interface ILessonService
	{
		void Add(CreateLessonViewModel lessonViewModel);

		Lesson? GetById(int id);

		void Update(UpdateLessonViewModel lessonViewModel);

		void Delete(int id);
	}
}
