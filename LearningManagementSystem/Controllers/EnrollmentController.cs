using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningManagementSystem.Controllers
{
	public class EnrollmentController : Controller
	{
		private readonly IEnrollmentService _enrollmentService;
		public EnrollmentController(IEnrollmentService enrollmentService)
		{
			_enrollmentService = enrollmentService;
		}


		[Authorize(Roles = "Student")]
		public IActionResult Enroll(int courseId)
		{
			string studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			_enrollmentService.Add(courseId, studentId);
			return RedirectToAction("Index", "Course");
		}


		[Authorize(Roles = "Instructor")]
		public IActionResult EnrolledStudents(int courseId)
		{
			List<ApplicationUser> students = _enrollmentService.GetEnrolledStudents(courseId);
			ViewBag.courseId = courseId;
			return View(students);
		}


		[Authorize(Roles = "Instructor")]
		public IActionResult UnEnroll(int courseId, string studentId)
		{
			_enrollmentService.Delete(courseId, studentId);
			return RedirectToAction("Details", "Course", new {id = courseId});
		}
	}
}
