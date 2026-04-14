using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IEnrollmentRepository
	{
		void Add(Enrollment enrollment);

		List<ApplicationUser> GetEnrolledStudents(int courseId);

		void Delete(Enrollment enrollment);


		Enrollment? GetById(int courseId, string studentId);
	}
}
