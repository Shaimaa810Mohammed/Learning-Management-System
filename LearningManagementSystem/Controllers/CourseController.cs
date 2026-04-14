using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningManagementSystem.Controllers
{
	//[Authorize(Roles = "Instructor")]
	public class CourseController : Controller
	{
		private readonly ICourseService _courseService;
		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		public IActionResult Index()
		
		{
			List<Course> courses = _courseService.GetAll();
			return View(courses);
		}


		[Authorize(Roles = "Instructor")]
		public IActionResult InstructorCourses()
		{
			string instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			List<Course> courses = _courseService.GetInstructorCourses(instructorId);
			return View("Courses", courses);
		}


		[Authorize(Roles = "Student")]
		public IActionResult StudentCourses()
		{
			string studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			List<Course> courses = _courseService.GetStudentCourses(studentId);
			return View("Courses", courses);
		}


		[HttpGet]
		[Authorize(Roles = "Instructor")]
		public IActionResult CreateCourse()
		{
			return View();
		}


		[HttpPost]
		[Authorize(Roles = "Instructor")]
		public IActionResult CreateCourse(CourseViewModel courseViewModel)
		{
			if (ModelState.IsValid)
			{
				string instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				_courseService.Add(courseViewModel, instructorId);
				return RedirectToAction("InstructorCourses");
			}
			return View(courseViewModel);
		}


		public IActionResult Details(int id)
		{
			Course? course = _courseService.GetById(id);
			if (course == null)
			{
				return NotFound("Invalid Course Id");
			}
			return View(course);
		}


		[HttpGet]
		[Authorize(Roles = "Instructor")]
		public IActionResult UpdateCourse(int id)
		{
			Course? course = _courseService.GetById(id);
			if (course == null)
			{
				return NotFound("Invalid Course Id");
			}
			CourseViewModel courseViewModel = new CourseViewModel();
			courseViewModel.Title = course.Title;
			courseViewModel.Description = course.Description;
			courseViewModel.Duration = course.duration;
			ViewBag.CourseId = id;
			return View(courseViewModel);
		}


		[HttpPost]
		[Authorize(Roles = "Instructor")]
		public IActionResult UpdateCourse(CourseViewModel courseViewModel, int courseId)
		{
			if (ModelState.IsValid)
			{
				_courseService.Update(courseViewModel, courseId);
				return RedirectToAction("Details", new {id = courseId});
			}
			return View(courseViewModel);
		}

		public IActionResult DeleteCourse(int id)
		{
			bool isDeleted = _courseService.Delete(id);
			if (isDeleted)
			{
				return RedirectToAction("InstructorCourses");
			}
			return NotFound("Invalid Course Id");
		}

	}
}
