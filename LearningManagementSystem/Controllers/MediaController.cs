using LearningManagementSystem.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
	public class MediaController : Controller
	{
		private readonly IMediaService _mediaService;
		private readonly ILessonService _lessonService;
		public MediaController(IMediaService mediaService, ILessonService lessonService)
		{
			_mediaService = mediaService;
			_lessonService = lessonService;
		}

		[HttpGet]
		public IActionResult AddMedia(int lessonId)
		{
			ViewBag.lessonId = lessonId;
			return View();
		}


		public IActionResult SaveMedia(IFormFile mediaFile, int lessonId)
		{
			if (mediaFile == null || mediaFile.Length == 0)
			{
				return BadRequest("No file selected");
			}
			_mediaService.Add(mediaFile, lessonId);
			return RedirectToAction("Details", "Course", new { id = _lessonService.GetById(lessonId).CourseId });	
		}


		public IActionResult DeleteMedia(int mediaId)
		{
			int courseId = _mediaService.GetById(mediaId).Lesson.CourseId;
			_mediaService.Delete(mediaId);
			return RedirectToAction("Details", "Course", new { id = courseId });
		}
	}
}
