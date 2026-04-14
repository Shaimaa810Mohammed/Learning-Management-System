using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface ICourseRepository
	{
		void Add(Course course);

		void Update(Course course);

		void Delete(Course course);

		Course? GetById(int id);

		List<Course> GetInstructorCourses(string instructorId);

		List<Course> GetStudentCourses(string studentId);


		List<Course> GetAll();
	}
}
