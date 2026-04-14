using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Repositories
{
	public class EnrollmentRepository : IEnrollmentRepository
	{
		private readonly DBContext _dbContext;
		public EnrollmentRepository(DBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public void Add(Enrollment enrollment)
		{
			_dbContext.Add(enrollment);
			_dbContext.SaveChanges();
		}

		public void Delete(Enrollment enrollment)
		{
			_dbContext.Remove(enrollment);
			_dbContext.SaveChanges();
		}

		public Enrollment? GetById(int courseId, string studentId)
		{
			return _dbContext.Enrollments.FirstOrDefault(e => e.ApplicationUserId == studentId && e.CourseId == courseId);
		}

		public List<ApplicationUser> GetEnrolledStudents(int courseId)
		{
			List<ApplicationUser> students = _dbContext.Enrollments.Include(e => e.ApplicationUser).Where(e => e.CourseId == courseId).Select(e => e.ApplicationUser).ToList();
			return students;
		}
	}
}
