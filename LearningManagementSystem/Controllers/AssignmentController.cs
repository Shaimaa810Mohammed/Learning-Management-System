using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
	public class AssignmentController : Controller
	{
		private readonly IAssignmentService _assignmentService;
		public AssignmentController(IAssignmentService assignmentService)
		{
			_assignmentService = assignmentService;
		}


		[Authorize(Roles = "Instructor")]
		public IActionResult CreateAssignment(int courseId)
		{
			return View(new AssignmentViewModel() { CourseId = courseId});
		}

		[HttpPost]
		public IActionResult SaveCreate(AssignmentViewModel assignmentViewModel)
		{
			if (ModelState.IsValid)
			{
				_assignmentService.Add(assignmentViewModel);
				return RedirectToAction("Details", "Course", new { id = assignmentViewModel.CourseId });
			}
			return View("CreateAssignment", assignmentViewModel);
		}

		public IActionResult DeleteAssignment(int assignmentId)
		{
			int courseId = _assignmentService.GetById(assignmentId).CourseId;
			_assignmentService.Delete(assignmentId);
			return RedirectToAction("Details", "Course", new { id = courseId });
		}


		public IActionResult UpdateAssignment(int assignmentId)
		{
			Assignment assignment = _assignmentService.GetById(assignmentId);
			UpdateAssignmentViewModel updateAssignmentViewModel = new UpdateAssignmentViewModel()
			{
				Title = assignment.Title,
				StartTime = assignment.StartTime,
				EndTime = assignment.EndTime,
				MaxDegree = assignment.TotalDegree,
			};
			ViewBag.assignmentId = assignmentId;
			return View(updateAssignmentViewModel);
		}


		public IActionResult SaveUpdate(UpdateAssignmentViewModel updateAssignmentViewModel, int assignmentId)
		{
			if (ModelState.IsValid)
			{
				_assignmentService.Update(updateAssignmentViewModel, assignmentId);
				int courseId = _assignmentService.GetById(assignmentId).CourseId;
				return RedirectToAction("Details", "Course", new { id = courseId });
			}
			ViewBag.assignmentId = assignmentId;
			return View("UpdateAssignment" ,updateAssignmentViewModel);
		}

	}
}
