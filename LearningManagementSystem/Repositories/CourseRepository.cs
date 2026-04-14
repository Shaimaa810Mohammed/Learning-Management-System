using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private readonly DBContext _dbContext;
		public CourseRepository(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(Course course)
		{
			_dbContext.Add(course);
			_dbContext.SaveChanges();
		}

		public void Delete(Course course)
		{
			_dbContext.Remove(course);
			_dbContext.SaveChanges();
		}

		public List<Course> GetInstructorCourses(string instructorId)
		{
			List<Course> courses = _dbContext.Courses.Where(c => c.ApplicationUserId == instructorId).ToList();
			return courses;
		}

		public Course? GetById(int id)
		{
			Course? course = _dbContext.Courses.Include(c => c.Lessons).ThenInclude(l => l.MediaFiles).Include(c => c.Assignments).ThenInclude(a => a.AssignmentSubmissions).Include(c => c.Quizzes).ThenInclude(q => q.QuizSubmissions).FirstOrDefault(c => c.Id == id);
			return course;
		}

		public void Update(Course course)
		{
			_dbContext.Update(course);
			_dbContext.SaveChanges();
		}

		public List<Course> GetAll()
		{
			List<Course> courses = _dbContext.Courses.Include(c => c.ApplicationUser).Include(c => c.Enrollments).ToList();
			return courses;
		}

		public List<Course> GetStudentCourses(string studentId)
		{
			List<Course> courses = _dbContext.Enrollments.Include(e => e.Course).Where(e => e.ApplicationUserId == studentId).Select(e => e.Course).ToList();
			return courses;
		}


	}
}
