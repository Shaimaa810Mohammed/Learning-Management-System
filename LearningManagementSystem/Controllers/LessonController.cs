using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
	[Authorize(Roles = "Instructor")]
	public class LessonController : Controller
	{
		private readonly ICourseService _courseService;
		private readonly ILessonService _lessonService;
		public LessonController(ICourseService courseService, ILessonService lessonService)
		{
			_courseService = courseService;
			_lessonService = lessonService;
		}


		[HttpGet]
		public IActionResult CreateLesson(int courseId)
		{
			return View(new CreateLessonViewModel() { CourseId = courseId});
		}

		[HttpPost]
		public IActionResult SaveLesson(CreateLessonViewModel lessonViewModel)
		{
			if (ModelState.IsValid)
			{
				Course? course = _courseService.GetById(lessonViewModel.CourseId);
				if ( course == null)
				{
					return NotFound("invalid course id");
				}
				_lessonService.Add(lessonViewModel);
				return RedirectToAction("Details", "Course", new { id = lessonViewModel.CourseId });
			}
			return View("CreateLesson", lessonViewModel);
		}


		[HttpGet]
		public IActionResult UpdateLesson(int lessonId)
		{
			Lesson? lesson = _lessonService.GetById(lessonId);
			if (lesson == null)
			{
				return NotFound("invalid lesson id");
			}
			UpdateLessonViewModel updateLessonViewModel = new UpdateLessonViewModel() { Title = lesson.Title, LessonId = lessonId };
			return View(updateLessonViewModel);
		}

		[HttpPost]
		public IActionResult SaveUpdate(UpdateLessonViewModel updateLessonViewModel)
		{
			if (ModelState.IsValid)
			{
				_lessonService.Update(updateLessonViewModel);
				return RedirectToAction("Details", "Course", new { id = _lessonService.GetById(updateLessonViewModel.LessonId).CourseId });
			}
			return View("UpdateLesson", updateLessonViewModel);
		}


		public IActionResult DeleteLesson(int lessonId) 
		{
			int courseId = _lessonService.GetById(lessonId).CourseId;
			_lessonService.Delete(lessonId);
			return RedirectToAction("Details", "Course", new {id = courseId});
		}


	}
}
