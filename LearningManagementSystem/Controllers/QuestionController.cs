using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
	[Authorize(Roles ="Instructor")]
	public class QuestionController : Controller
	{
		private readonly ICourseService _courseService;
		private readonly IQuestionService _questionService;
		public QuestionController(ICourseService courseService, IQuestionService questionService)
		{
			_courseService = courseService;
			_questionService = questionService;
		}

		public IActionResult Index(int courseId)
		{
			List<Question> questions = _questionService.GetCourseQuestions(courseId);

			return View(questions);
		}


		public IActionResult CreateQuestion(int courseId)
		{
			QuestionViewModel questionViewModel = new QuestionViewModel();
			questionViewModel.AnswerOptions = new List<string>();
			questionViewModel.AnswerOptions.Add("");
			questionViewModel.AnswerOptions.Add("");
			questionViewModel.CourseId = courseId;
			return View(questionViewModel);
		}


		[HttpPost]
		public IActionResult SaveCreate(QuestionViewModel questionViewModel)
		{
			if(ModelState.IsValid)
			{
				_questionService.Add(questionViewModel);
				return RedirectToAction("Index", new {courseId=questionViewModel.CourseId});
			}
			return View("CreateQuestion", questionViewModel);
		}

		public IActionResult DeleteQuestion(int questionId)
		{
			int courseId = _questionService.GetById(questionId).CourseId;
			_questionService.Delete(questionId);
			return RedirectToAction("Index", new { courseId = courseId });
		}

		public IActionResult UpdateQuestion(int questionId)
		{
			Question? question = _questionService.GetById(questionId);
			QuestionViewModel questionViewModel = new QuestionViewModel();
			questionViewModel.QuestionText = question.QuestionText;
			questionViewModel.AnswerOptions = question.AnswerOptions;
			questionViewModel.CorrectAnswer = question.CorrectAnswer;
			questionViewModel.QuestionType = question.QuestionType;
			questionViewModel.MaxDegree = question.MaxDegree;
			questionViewModel.CourseId = question.CourseId;
			ViewBag.questionId = questionId;
			return View(questionViewModel);
		}


		public IActionResult SaveUpdate(QuestionViewModel questionViewModel, int questionId)
		{
			if (ModelState.IsValid)
			{
				int courseId = _questionService.GetById(questionId).CourseId;
				questionViewModel.CourseId = courseId;
				_questionService.Update(questionViewModel, questionId);
				return RedirectToAction("Index", new { courseId = courseId });
			}
			ViewBag.questionId = questionId;
			return View("UpdateQuestion", questionViewModel);
		}

	}
}
