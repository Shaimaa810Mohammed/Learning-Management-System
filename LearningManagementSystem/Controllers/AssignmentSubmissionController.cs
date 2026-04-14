using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningManagementSystem.Controllers
{
	public class AssignmentSubmissionController : Controller
	{
		private readonly IAssignmentSubmissionService _assignmentSubmissionService;
		private readonly IAssignmentService _assignmentService;
		public AssignmentSubmissionController(IAssignmentSubmissionService assignmentSubmissionService, IAssignmentService assignmentService)
		{
			_assignmentSubmissionService = assignmentSubmissionService;
			_assignmentService = assignmentService;
		}

		public IActionResult AddSubmission(int assignmentId, IFormFile solutionFile)
		{
			string studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			_assignmentSubmissionService.Add(assignmentId, studentId, solutionFile);
			int courseId = _assignmentService.GetById(assignmentId).CourseId;
			return RedirectToAction("Details", "Course", new { id = courseId });
		}


		public IActionResult UncheckedSubmissions(int assignmentId)
		{
			List<AssignmentSubmission> submissions = _assignmentSubmissionService.GetUncheckedAssignmentSubmissions(assignmentId);
			return View(submissions);
		}

		public IActionResult SaveSubmissionDegree(int assignmentId, string studentId, int degree)
		{
			_assignmentSubmissionService.SaveSubmissionDegree(assignmentId, studentId, degree);
			return RedirectToAction("UncheckedSubmissions", new { assignmentId = assignmentId });
		}
	}
}
