using LearningManagementSystem.Models;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.ServiceContracts
{
	public interface ICourseService
	{
		void Add(CourseViewModel courseViewModel, string instructorId);

		List<Course> GetInstructorCourses(string instructorId);

		Course? GetById(int id);

		void Update(CourseViewModel courseViewModel, int courseId);

		bool Delete(int id);

		List<Course> GetAll();


		List<Course> GetStudentCourses(string studentId);
	}
}
