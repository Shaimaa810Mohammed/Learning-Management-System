using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;

namespace LearningManagementSystem.Services
{
	public class EnrollmentService : IEnrollmentService
	{
		private readonly IEnrollmentRepository _enrollmentRepository;
		public EnrollmentService(IEnrollmentRepository enrollmentRepository)
		{
			_enrollmentRepository = enrollmentRepository;
		}


		public void Add(int courseId, string studentId)
		{
			Enrollment enrollment = new Enrollment()
			{
				CourseId = courseId,
				ApplicationUserId = studentId,
			};

			_enrollmentRepository.Add(enrollment);
		}

		public void Delete(int courseId, string studentId)
		{
			Enrollment? enrollment = _enrollmentRepository.GetById(courseId, studentId);
			_enrollmentRepository.Delete(enrollment);
		}

		public Enrollment? GetById(int courseId, string studentId)
		{
			return _enrollmentRepository.GetById(courseId, studentId);
		}

		public List<ApplicationUser> GetEnrolledStudents(int courseId)
		{
			 return _enrollmentRepository.GetEnrolledStudents(courseId);
		}
	}
}
