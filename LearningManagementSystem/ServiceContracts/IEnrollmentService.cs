using LearningManagementSystem.Models;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IEnrollmentService
	{
		void Add(int courseId, string studentId);

		List<ApplicationUser> GetEnrolledStudents(int courseId);


		void Delete(int courseId, string studentId);


		Enrollment? GetById(int courseId, string studentId);
	}
}
