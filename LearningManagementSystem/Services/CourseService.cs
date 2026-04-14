using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.Services
{
	public class CourseService : ICourseService
	{
		private readonly ICourseRepository _courseRepository;
		private readonly IQuestionRepository _questionRepository;
		public CourseService(ICourseRepository courseRepository, IQuestionRepository questionRepository)
		{
			_courseRepository = courseRepository;
			_questionRepository = questionRepository;
		}

		public void Add (CourseViewModel courseViewModel, string instructorId)
		{
			Course course = new Course();
			course.Title = courseViewModel.Title;
			course.Description = courseViewModel.Description;
			course.duration = courseViewModel.Duration;
			course.ApplicationUserId = instructorId;
			_courseRepository.Add(course);
		}

		public bool Delete(int id)
		{
			Course? course = _courseRepository.GetById(id);
			if (course == null)
			{
				return false;
			}
			List<Question> questions = _questionRepository.GetCourseQuestions(id);
			foreach (Question question in questions)
			{
				_questionRepository.Delete(question);
			}
			_courseRepository.Delete(course);
			return true;
		}

		public List<Course> GetInstructorCourses(string instructorId)
		{
			return _courseRepository.GetInstructorCourses(instructorId);
		}

		public Course? GetById(int id)
		{
			return _courseRepository.GetById(id);
		}

		public void Update(CourseViewModel courseViewModel, int courseId)
		{
			Course oldCourse = GetById(courseId);
			oldCourse.Title = courseViewModel.Title;
			oldCourse.Description = courseViewModel.Description;
			oldCourse.duration = courseViewModel.Duration;
			_courseRepository.Update(oldCourse);
		}

		public List<Course> GetAll()
		{
			return _courseRepository.GetAll();
		}

		public List<Course> GetStudentCourses(string studentId)
		{
			return _courseRepository.GetStudentCourses(studentId);
		}
	}
}
